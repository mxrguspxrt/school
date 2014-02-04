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
        string _name;
        bool _waiting;

        [DataMember]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [DataMember]
        public bool Waiting
        {
            get { return this._waiting; }
            set { this._waiting = value; }
        }

        public GameUser()
        {

        }

        public GameUser(DBA.User u)
        {
            this.Name = u.Name;
            this.Id = u.Id;
        }

        public static GameUser Find(int id)
        {
            using (var db = getDBConnection())
            {
                DBA.User uf = db.UserSet.Find(id);
                return uf!=null ? new GameUser(uf) : null;
            }
        }

        // TODO smart ask if not playing but online
        public static List<GameUser> Waiters()
        {
            using (var db = getDBConnection())
            {
                var query = (from x in db.UserSet where x.Waiting==true select x).ToList();
                return query.Select(x => new GameUser(x)).ToList();
            }
        }

        public bool Save()
        {
            using (var db = getDBConnection())
            {
                DBA.User u = new DBA.User();
                u.Id = this.Id;
                u.Name = this.Name;
                db.UserSet.Add(u);
                db.SaveChanges();
                this.Id = u.Id;
                return true;
            }
        }

    }
}
