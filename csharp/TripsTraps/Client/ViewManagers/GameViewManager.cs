using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.ViewManagers
{
    class GameViewManager
    {
        public static GameViewManager Current;
        public Models.GameUser CurrentGameUser;
        public Models.GamePlay CurrentGamePlay;

        public string CurrentGamePlayInfo
        {
            get { return CurrentGamePlay.Inspect(); }
        }

        public Models.GameUser CreateGameUser(string gameUserName)
        {
            this.CurrentGameUser = new Models.GameUser()
            {
                Name = gameUserName
            };
            this.CurrentGameUser.Save();
            return this.CurrentGameUser;
        }

        public Models.GamePlay CreateGamePlay()
        {
            this.CurrentGamePlay = Models.GamePlay.FindForGameUser(this.CurrentGameUser.Id);
            return this.CurrentGamePlay;
        }

        public async Task<bool> WaitForOtherPlayer()
        {
            while(this.CurrentGamePlay.State=="waiting_player")
            {
                this.CurrentGamePlay.Reload();
                await Task.Delay(1000);
            }
            return true;
        }

        public async Task<bool> RefreshGamePlayData()
        {
            return this.CurrentGamePlay.Reload();
        }

    }
}
