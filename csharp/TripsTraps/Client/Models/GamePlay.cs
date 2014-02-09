using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Client.Models
{
    class GamePlay
    {
        
        static public GamePlay Current;

        public GameUser GameUser;
        public int Id;
        public int CurrentUserId;
        public string State;
        public int MoverUserId;
        public int[] GameTable;
        public int[] WinningCombination;
        public bool CanMakeNewMoves;

        Thread _UpdateThread;

        public bool SetValuesFrom(TripsService.GamePlay gamePlay)
        {
            this.Id = gamePlay.Id;
            this.State = gamePlay.State;
            this.MoverUserId = gamePlay.MoverUserId;
            this.GameTable = gamePlay.GameTable;
            this.WinningCombination = gamePlay.WinningCombination;
            this.CanMakeNewMoves = gamePlay.CanMakeNewMoves;
            this.CurrentUserId = GameUser.Id;
            return true;
        }

        public GamePlay()
        {

        }

        public GamePlay(TripsService.GamePlay gamePlay)
        {
            this.SetValuesFrom(gamePlay);
        }

        public bool Start(string gameUserName)
        {
            this.GameUser = new GameUser()
            {
                Name = gameUserName
            };
            this.GameUser.Save();

            this.StartUpdatingValues();

            return true;
        }

        public bool End()
        {
            return this.EndUpdatingValues();
        }

        public bool Save()
        {
            return Create();
        }

        public bool Create()
        {
            TripsService.TripsServiceClient resource = new TripsService.TripsServiceClient();
            TripsService.GamePlay gamePlay = resource.GamePlay_Request(CurrentUserId);
            this.SetValuesFrom(gamePlay);
            return true;
        }


        public void Reload()
        {
            TripsService.TripsServiceClient resource = new TripsService.TripsServiceClient();
            TripsService.GamePlay gamePlay = resource.GamePlay_Show(this.Id);
            this.SetValuesFrom(gamePlay);
        }

        public bool StartUpdatingValues()
        {
            this._UpdateThread = new Thread(new ThreadStart(this.Reload));
            return true;
        }

        public bool EndUpdatingValues()
        {
            this._UpdateThread.Abort();
            return true;
        }

    }
}
