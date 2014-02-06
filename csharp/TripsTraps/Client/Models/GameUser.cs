using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Client.Models
{
    class GameUser
    {
        int _Id;
        string _Name;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value;  }
        }

        public GameUser()
        {
        }

        public bool Save()
        {
            Server.GameUsersServiceClient s = new Server.GameUsersServiceClient();
            Server.GameUser gameUser = s.Register(Name);
            Id = gameUser.Id;
            Debug.WriteLine("Created user " + Name + " with id " + Id);
            return true;
        }

    }
}
