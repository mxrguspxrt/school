using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using TodoServer.Models;

namespace TodoServer.DAL
{
    public class TodoServerContext : DbContext
    {
        public DbSet<TodoServer.Models.Task> Tasks { get; set; }
        public DbSet<TodoServer.Models.Todo> Todos { get; set; }
        
        public TodoServerContext():base("name=TodoServerBase")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}
