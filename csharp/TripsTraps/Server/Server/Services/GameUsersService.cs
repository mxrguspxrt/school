using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GameUsersService : IGameUsersService
    {
        public Models.GameUser Register(string name)
        {
            Models.GameUser gameUser = new Models.GameUser();
            gameUser.Name = name;
            gameUser.Waiting = true;
            gameUser.Save();
            return gameUser;
        }

        public Models.GameUser Unregister(int id)
        {
            Models.GameUser gameUser = Models.GameUser.Find(id);
            gameUser.Waiting = false;
            gameUser.Save();
            return gameUser;
        }

        public List<Models.GameUser> Waiters()
        {
            return Models.GameUser.Waiters();
        }

    }
}
