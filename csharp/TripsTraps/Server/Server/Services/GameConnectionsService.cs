using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services
{

    public class GameConnectionsService : IGameConnectionsService
    {
    
        public Models.GameConnection Register(int gameUserId)
        {
            return Models.GameConnection.CreateGameConnectionOrJoin(gameUserId);
        }

        public Models.GameConnection Status(int id)
        {
            return Models.GameConnection.Find(id);
        }

    }
}
