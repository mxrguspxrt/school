using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Server.Models
{

    [DataContract]
    public class GameConnection : BaseModel
    {
        int _callerUserId;
        int? _calledUserId;
        int? _currentPlayId;

        [DataMember]
        public int CallerUserId
        {
            get { return this._callerUserId; }
            set { this._callerUserId = value; }
        }

        [DataMember]
        public int? CalledUserId
        {
            get { return this._calledUserId; }
            set { this._calledUserId = value; }
        }

        [DataMember]
        public int? CurrentPlayId
        {
            get { return this._currentPlayId; }
            set { this._currentPlayId = value; }
        }


        public GameConnection()
        {

        }

        public GameConnection(DBA.Connection u)
        {
            this.CallerUserId = u.CallerUserId;
            this.CalledUserId = u.CalledUserId;
            this.CurrentPlayId = u.CurrentPlayId;
            this.Id = u.Id;
        }

        public static GameConnection Find(int id)
        {
            using (var db = getDBConnection())
            {
                DBA.Connection uf = db.ConnectionSet.Find(id);
                return uf != null ? new GameConnection(uf) : null;
            }
        }

        public static GameConnection CreateGameConnectionOrJoin(int gameUserId)
        {
            using (var db = getDBConnection())
            {
                var query = (from x in db.ConnectionSet where x.CalledUserId == null select x).FirstOrDefault();
                if (query == null)
                {
                    Models.GameConnection gameConnection = new Models.GameConnection();
                    gameConnection.CallerUserId = gameUserId;
                    gameConnection.Save();
                    return gameConnection;
                }
                else
                {
                    Models.GameConnection gameConnection = new Models.GameConnection(query);
                    gameConnection.CalledUserId = gameUserId;
                    gameConnection.CreateNewPlay();
                    gameConnection.Save();
                    return gameConnection;
                }
            }
        }

        public bool Save()
        {
            using (var db = getDBConnection())
            {
                DBA.Connection u = new DBA.Connection();
                u.Id = this.Id;
                u.CallerUserId = this.CallerUserId;
                u.CalledUserId = this.CalledUserId;
                db.ConnectionSet.Add(u);
                db.SaveChanges();
                this.Id = u.Id;
                return true;
            }
        }

        public bool CreateNewPlay()
        {
            Models.GamePlay play = new Models.GamePlay();
            play.ConnectionId = this.Id;
            play.Save();
            this.CurrentPlayId = play.Id;
            this.Save();
            return true;
        }

    }
}
