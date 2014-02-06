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

        string _State;
        int _MoverUserId;

        [DataMember]
        public string State
        {
            get { return this._State; }
            set { this._State = value; }
        }

        [DataMember]
        public int MoverUserId
        {
            get { return this._MoverUserId; }
            set { this._MoverUserId = value; }
        }

        [DataMember]
        public List<GameMove> GameMoves
        {
            get { return Models.GameMove.FindForPlay(this.Id); }
        }

        [DataMember]
        public List<GameUser> GameUsers
        {
            get { return Models.GameUser.FindForPlay(this.Id);  }
        }

        public static List<int[]> WinningRows()
        {
            List<int[]> winningRows = new List<int[]>();
            winningRows.Add(new int[] { 0, 1, 2 });
            winningRows.Add(new int[] { 3, 4, 5 });
            winningRows.Add(new int[] { 6, 7, 8 });
            winningRows.Add(new int[] { 0, 3, 6 });
            winningRows.Add(new int[] { 1, 4, 7 });
            winningRows.Add(new int[] { 2, 5, 8 });
            winningRows.Add(new int[] { 0, 4, 8 });
            winningRows.Add(new int[] { 2, 4, 6 });
            return winningRows;
        }

        [DataMember]
        public int[] WinningRow
        {
            get
            {

            }
        }

        public GamePlay()
        {

        }

        public GamePlay(DBA.Play u)
        {
            this.Id = u.Id;
            this.MoverUserId = u.MoverUserId;
            this.State = u.State;
        }

        public static GamePlay Find(int id)
        {
            using (var db = getDBConnection())
            {
                DBA.Play uf = db.PlaySet.Find(id);
                return uf != null ? new GamePlay(uf) : null;
            }
        }

        public static GamePlay FindGamePlayFor(int userId)
        {
            using (var db = getDBConnection())
            {
                Models.GamePlay gamePlay;
                Models.GameUser gameUser = Models.GameUser.Find(userId);
                DBA.Play dbInstance = (from x in db.PlaySet where x.State=="waiting_player" select x).FirstOrDefault();

                if (dbInstance != null)
                {
                    gamePlay = new Models.GamePlay(dbInstance);
                    gamePlay.State = "active";
                    gamePlay.Save();
                    gameUser.CurrentPlayId = gamePlay.Id;
                    gameUser.Save();
                }
                else
                {
                    gamePlay = new Models.GamePlay();
                    gamePlay.State = "waiting_player";
                    gamePlay.MoverUserId = gameUser.Id;
                    gamePlay.Save();
                    gameUser.CurrentPlayId = gamePlay.Id;
                    gameUser.Save();
                }
                return gamePlay;
            }
        }

        public bool Save()
        {
            using (var db = getDBConnection())
            {
                if (Id == 0)
                {
                    DBA.Play i = new DBA.Play();
                    i.State = this.State;
                    i.MoverUserId = this.MoverUserId;
                    db.PlaySet.Add(i);
                    db.SaveChanges();
                    this.Id = i.Id;
                }
                else
                {
                    DBA.Play i = db.PlaySet.Find(Id);
                    i.State = this.State;
                    i.MoverUserId = this.MoverUserId;
                    db.SaveChanges();
                }
                return true;
            }
        }

        public bool Move(int userId, int position)
        {
            if (position > 8) return false;
            if (this.State != "active") return false;
            if (this.MoverUserId != userId) return false;
            if (this.GameMoves.FirstOrDefault(e => e.Position==position)!=null) return false;

            GameMove move = new GameMove()
            {
                UserId = userId,
                PlayId = Id,
                Position = position
            };
            move.Save();

            if(this.CanMakeNewMoves())
            {
                this.MoverUserId = GameUsers.FirstOrDefault(e => e.Id != this.MoverUserId).Id;
                this.Save();
            }
            else
            {
                this.State = "ended";
                this.Save();
            }

            return true;
        }

        public bool CanMakeNewMoves()
        {
            return (WinningRow == null) && (this.GameMoves.Count<10);
        }

    }
}
