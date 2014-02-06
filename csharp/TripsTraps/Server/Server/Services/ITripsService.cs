using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITripsService" in both code and config file together.
    [ServiceContract]
    public interface ITripsService
    {

        [OperationContract]
        Models.GameUser GameUser_Register(string name);

        [OperationContract]
        Models.GameUser GameUser_Unregister(int id);

        [OperationContract]
        Models.GamePlay GamePlay_Request(int userId);

        [OperationContract]
        Models.GamePlay GamePlay_Show(int gamePlayId);

        [OperationContract]
        Models.GamePlay GamePlay_Move(int gamePlayId, int userId, int position);


    }
}
