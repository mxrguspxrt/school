using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Server.Models
{

    [DataContract]
    public class GameUser : BaseModel
    {
        string _Name;
        int _CurrentPlayId;
        bool _Active;

        [DataMember]
        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }

        [DataMember]
        public int CurrentPlayId
        {
            get { return this._CurrentPlayId; }
            set { this._CurrentPlayId = value; }
        }

        [DataMember]
        public bool Active
        {
            get { return this._Active; }
            set { this._Active = value; }
        }

        public GameUser()
        {

        }

        public GameUser(DBA.User u)
        {
            this.Id = u.Id;
            this.Name = u.Name;
            this.CurrentPlayId = u.CurrentPlayId;
            this.Active = u.Active;
        }

        public static GameUser Find(int id)
        {
            using (var db = getDBConnection())
            {
                DBA.User uf = db.UserSet.Find(id);
                return uf!=null ? new GameUser(uf) : null;
            }
        }

        public static List<GameUser> FindForPlay(int id)
        {
            using (var db = getDBConnection())
            {
                var query = (from x in db.UserSet where x.CurrentPlayId == id select x).ToList();
                return query.Select(x => new GameUser(x)).ToList();
            }
        }

        public bool Save()
        {
            using (var db = getDBConnection())
            {
                if(Id==0)
                {
                    DBA.User i = new DBA.User();
                    i.Name = this.Name;
                    i.CurrentPlayId = this.CurrentPlayId;
                    i.Active = this.Active;
                    db.UserSet.Add(i);
                    db.SaveChanges();
                    this.Id = i.Id;
                }
                else
                {
                    DBA.User i = db.UserSet.Find(Id);
                    i.Name = this.Name;
                    i.CurrentPlayId = this.CurrentPlayId;
                    i.Active = this.Active;
                    db.SaveChanges();
                }
                return true;
            }
        }

    }
}
