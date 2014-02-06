using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    class Overview
    {
        public static Overview Active;
        public Models.GameUser GameUser;

        public bool RegisterGameUser(string name)
        {
            GameUser = new Models.GameUser();
            GameUser.Name = name;
            GameUser.Save();
            return true;
        }

    }
}
