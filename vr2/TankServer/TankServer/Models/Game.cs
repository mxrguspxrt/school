using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using TankServer.DAL;

namespace TankServer.Models
{
    public class Game : BaseModel<Game>
    {
        public int Id { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual Map Map { get; set; }
    }
}