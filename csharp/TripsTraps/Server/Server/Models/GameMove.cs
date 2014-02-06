using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace Server.Models
{

    [DataContract]
    public class GameMove : BaseModel
    {
        int _UserId;
        int _PlayId;
        int _Position;

        [DataMember]
        public int UserId
        {
            get { return this._UserId; }
            set { this._UserId = value; }
        }

        [DataMember]
        public int PlayId
        {
            get { return this._PlayId; }
            set { this._PlayId = value; }
        }

        [DataMember]
        public int Position
        {
            get { return this._Position; }
            set { this._Position = value; }
        }

        public GameMove()
        {

        }

        public GameMove(DBA.Move u)
        {
            this.UserId = u.UserId;
            this.Position = u.Position;
            this.PlayId = u.PlayId;
            this.Id = u.Id;
        }

        public static List<GameMove> FindForPlay(int id)
        {
            using (var db = getDBConnection())
            {
                var query = (from x in db.MoveSet where x.PlayId == id select x).ToList();
                return query.Select(x => new GameMove(x)).ToList();
            }
        }

        public bool Save()
        {
            using (var db = getDBConnection())
            {
                if (Id == 0)
                {
                    DBA.Move i = new DBA.Move();
                    i.UserId = this.UserId;
                    i.PlayId = this.PlayId;
                    i.Position = this.Position;
                    Debug.WriteLine(UserId + " " + PlayId + " " + Position);
                    db.MoveSet.Add(i);
                    db.SaveChanges();
                    this.Id = i.Id;
                }
                else
                {
                    DBA.Move i = db.MoveSet.Find(Id);
                    i.UserId = this.UserId;
                    i.PlayId = this.PlayId;
                    i.Position = this.Position;
                    db.SaveChanges();
                }
                return true;
            }
        }

    }
}
