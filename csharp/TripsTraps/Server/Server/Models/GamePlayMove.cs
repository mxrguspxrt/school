using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Server.Models
{

    [DataContract]
    public class GamePlayMove : BaseModel
    {
        int _userId;
        int _position;

        [DataMember]
        public int UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        [DataMember]
        public int Position
        {
            get { return this._position; }
            set { this._position = value; }
        }

        public GamePlayMove()
        {

        }

        public GamePlayMove(DBA.PlayMove u)
        {
            this.UserId = u.UserId;
            this.Position = u.Position;
            this.Id = u.Id;
        }

        public static List<GamePlayMove> FindForPlay(int id)
        {
            using (var db = getDBConnection())
            {
                var query = (from x in db.PlayMoveSet where x.PlayId == id select x).ToList();
                return query.Select(x => new GamePlayMove(x)).ToList();
            }
        }

        public bool Save()
        {
            using (var db = getDBConnection())
            {
                DBA.PlayMove u = new DBA.PlayMove();
                u.Id = this.Id;
                u.UserId = this.UserId;
                u.Position = this.Position;
                db.PlayMoveSet.Add(u);
                db.SaveChanges();
                this.Id = u.Id;
                return true;
            }
        }

    }
}
