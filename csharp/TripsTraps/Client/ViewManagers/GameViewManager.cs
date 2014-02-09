using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewManagers
{
    class GameViewManager
    {
        public static GameViewManager Current;
        public Models.GameUser CurrentGameUser;
        public Models.GamePlay CurrentGamePlay;

        public bool Start(string gameUserName)
        {
            this.CurrentGameUser = new Models.GameUser()
            {
                Name = gameUserName
            };
            this.CurrentGameUser.Save();
            this.CurrentGamePlay = Models.GamePlay.FindForGameUser(CurrentGameUser.Id);

            return true;
        }

    }
}
