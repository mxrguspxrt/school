using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Server.Models
{

    [DataContract]
    public class GamePlay : BaseModel
    {
        int _connectionId;
        List<GamePlayMove> _gamePlayMoves;

        [DataMember]
        public int ConnectionId
        {
            get { return this._connectionId; }
            set { this._connectionId = value; }
        }

        [DataMember]
        public List<GamePlayMove> GamePlayMoves
        {
            get { return this._gamePlayMoves; }
            set { this._gamePlayMoves = value; }
        }

        public GamePlay()
        {

        }

        public GamePlay(DBA.Play u)
        {
            this.ConnectionId = u.ConnectionId;
            this.Id = u.Id;
            this.GamePlayMoves = Models.GamePlayMove.FindForPlay(this.Id);
        }

        public static GamePlay Find(int id)
        {
             using (var db = getDBConnection())
            {
                DBA.Play uf = db.PlaySet.Find(id);
                return uf != null ? new GamePlay(uf) : null;
            }
        }

        public bool Save()
        {
            using (var db = getDBConnection())
            {
                DBA.Play u = new DBA.Play();
                u.Id = this.Id;
                u.ConnectionId = this.ConnectionId;
                db.PlaySet.Add(u);
                db.SaveChanges();
                this.Id = u.Id;
                return true;
            }
        }

    }
}
