using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    public class BaseModel
    {
        int _Id;

        [DataMember]
        public int Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }

        public static DBA.TripsContainer getDBConnection()
        {
            return new DBA.TripsContainer();
        }

    }

}
