using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TankServer.Models;

namespace TankServer.DAL
{
    public class TankServerContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<MapItem> MapItems { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }

        public TankServerContext():base("name=TankServerBase")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}
