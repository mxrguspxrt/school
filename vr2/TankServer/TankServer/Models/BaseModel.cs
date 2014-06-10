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

        public int? Id { get; set; }

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

        public static T Find(int id)
        {
            return Table.Find(id);
        }

        public bool Save()
        {
            if(Id==null)
            {
                //DB.Set<Game>().Add(new Game());
                //DB.Games.Add(new Game());
                T x = (T)(object) this;
                Table.Add(x);
                DB.SaveChanges();
            }
            return DB.SaveChanges() > 0;
        }


    }
}