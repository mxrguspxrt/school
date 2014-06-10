using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public virtual Position Position { get; set; }

        public User()
        {
            this.Position = new Position();
        }
    }
}