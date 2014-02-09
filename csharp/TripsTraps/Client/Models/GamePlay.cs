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

        public bool SetValuesFrom(TripsService.GamePlay gamePlay)
        {
            this.Id = gamePlay.Id;
            this.State = gamePlay.State;
            this.MoverUserId = gamePlay.MoverUserId;
            this.GameTable = gamePlay.GameTable;
            this.WinningCombination = gamePlay.WinningCombination;
            this.CanMakeNewMoves = gamePlay.CanMakeNewMoves;
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

    }
}
