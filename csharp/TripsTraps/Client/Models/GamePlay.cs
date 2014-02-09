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
        public int Id;
        public string State;
        public int MoverUserId;
        public int[] GameTable;
        public int[] WinningCombination;
        public bool CanMakeNewMoves;
        public DateTime LastReloadTime;

        public bool SetValuesFrom(TripsService.GamePlay gamePlay)
        {
            this.Id = gamePlay.Id;
            this.State = gamePlay.State;
            this.MoverUserId = gamePlay.MoverUserId;
            this.GameTable = gamePlay.GameTable;
            this.WinningCombination = gamePlay.WinningCombination;
            this.CanMakeNewMoves = gamePlay.CanMakeNewMoves;
            this.LastReloadTime = DateTime.Now;
            return true;
        }

        public GamePlay()
        {

        }

        public GamePlay(TripsService.GamePlay gamePlay)
        {
            this.SetValuesFrom(gamePlay);
        }

        public static GamePlay FindForGameUser(int gameUserId)
        {
            TripsService.TripsServiceClient link = new TripsService.TripsServiceClient();
            TripsService.GamePlay resource = link.GamePlay_Request(gameUserId);
            GamePlay gamePlay = new GamePlay();
            gamePlay.SetValuesFrom(resource);
            System.Diagnostics.Debug.WriteLine("Found GamePlay " + gamePlay.Id);
            return gamePlay;
        }

        public bool Reload()
        {
            TripsService.TripsServiceClient link = new TripsService.TripsServiceClient();
            TripsService.GamePlay resource = link.GamePlay_Show(this.Id);
            System.Diagnostics.Debug.WriteLine("Reloaded GamePlay " + this.Id);
            return this.SetValuesFrom(resource);
        }

        public string Inspect()
        {
            return String.Format("Id {0}, State {1}, MoverUserId {2}, CanMakeNewMoves {3}, LastReloadTime {4}", 
                Id, State, MoverUserId, CanMakeNewMoves, LastReloadTime);
        }

        public bool Move(int gameUserId, int position)
        {
            if (!this.CanMakeNewMoves) return false;
            if (this.MoverUserId != gameUserId) return false;
            if (this.GameTable[position] != 0) return false;
            
            TripsService.TripsServiceClient link = new TripsService.TripsServiceClient();
            TripsService.GamePlay resource = link.GamePlay_Move(this.Id, gameUserId, position);
            System.Diagnostics.Debug.WriteLine("Made move " + this.Id + " " + gameUserId + " " + position);
            System.Diagnostics.Debug.WriteLine("Reloaded GamePlay " + this.Id);
            return this.SetValuesFrom(resource);
        }

    }
}
