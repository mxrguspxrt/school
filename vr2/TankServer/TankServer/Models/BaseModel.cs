using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using TankServer.DAL;

namespace TankServer.Models
{
   
    public class BaseModel<T> where T : class
    {

        public static TankServerContext DB
        {
            get { return new TankServerContext(); }
        }

        public static DbSet<T> Table
        {
            get { return DB.Set<T>(); }
        }

        public static List<T> All()
        {
            return Table.ToList();
        }


    }
}