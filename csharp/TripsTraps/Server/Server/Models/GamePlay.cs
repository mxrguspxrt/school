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
    public class GamePlay : BaseModel
    {
        static int[,] WinningCombinations = {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };
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

        [DataMember]
        public int[] GameTable
        {
            get 
            {
                int[] gameTable = new int[9];
                foreach(GameMove gameMove in this.GameMoves)
                {
                    gameTable[gameMove.Position] = gameMove.UserId;
                }
                return gameTable;
            }
        }

        [DataMember]
        public int[] WinningCombination
        {
            get
            {
                for (int i = 0; i < WinningCombinations.GetLength(0); i++)
                {
                    int x = this.GameTable[WinningCombinations[i, 0]];
                    int y = this.GameTable[WinningCombinations[i, 1]];
                    int z = this.GameTable[WinningCombinations[i, 2]];
                    if(x!=0 && x==y && y==z)
                    {
                        return new int[3] { 
                            WinningCombinations[i, 0],
                            WinningCombinations[i, 1],
                            WinningCombinations[i, 2]
                        };
                    }
                }
                return null;
            }
        }

        [DataMember]
        public bool CanMakeNewMoves
        {
            get 
            {
                return (WinningCombination == null) && (this.GameMoves.Count < 10);
            }
            set
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

            if(this.CanMakeNewMoves)
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

    }
}
