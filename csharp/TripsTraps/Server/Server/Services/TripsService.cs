using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services
{

    public class TripsService : ITripsService
    {
        public Models.GameUser GameUser_Register(string name)
        {
            Models.GameUser gameUser = new Models.GameUser();
            gameUser.Name = name;
            gameUser.Active = true;
            gameUser.Save();
            return gameUser;
        }

        public Models.GameUser GameUser_Unregister(int id)
        {
            Models.GameUser gameUser = new Models.GameUser();
            gameUser.Active = false;
            gameUser.Save();
            return gameUser;
        }

        public Models.GamePlay GamePlay_Request(int userId)
        {
            Models.GamePlay gamePlay = Models.GamePlay.FindGamePlayFor(userId);
            return gamePlay;
        }

        public Models.GamePlay GamePlay_Show(int gamePlayId)
        {
            Models.GamePlay gamePlay = Models.GamePlay.Find(gamePlayId);
            return gamePlay;
        }

        public Models.GamePlay GamePlay_Move(int gamePlayId, int userId, int position)
        {
            Models.GamePlay gamePlay = Models.GamePlay.Find(gamePlayId);
            gamePlay.Move(userId, position);
            return gamePlay;
        }

    }
}
