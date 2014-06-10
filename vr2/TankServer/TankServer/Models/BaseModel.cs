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

        public static DbContext DbContext { get; set; }

        public static DbSet<T> DbTable { get; set; }

        public static DbSet<T> GetDbTable()
        {
            if(DbContext==null) DbContext = new TankServerContext();
            if(DbTable==null) DbTable = DbContext.Set<T>();
            return DbTable;
        }

        public static List<T> All()
        {
            return GetDbTable().ToList();
        }

        public static T Find(int id)
        {
            return GetDbTable().Find(id);
        }

        public bool Save()
        {
            if(Id==null)
            {
                //DB.Set<Game>().Add(new Game());
                //DB.Games.Add(new Game());
                GetDbTable().Add((T)(object)this);
                bool saved = DbContext.SaveChanges() > 0;
            }
            return DbContext.SaveChanges() > 0;
        }


    }
}