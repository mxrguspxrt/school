using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using TodoServer.DAL;
using System.Collections;


namespace TodoServer.Models
{

    public class BaseModel<T> where T : class
    {
        public int? Id { get; set; }
        public DateTime? CreatedAt { get; set; }

        public static DbContext DbContext { get; set; }

        public static DbSet<T> DbTable { get; set; }

        public static DbSet<T> GetDbTable()
        {
            if(DbContext==null) DbContext = new TodoServerContext();
            if(DbTable==null) DbTable = DbContext.Set<T>();
            return DbTable;
        }

        public static DbSet<T> All()
        {
            return GetDbTable();
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
                this.CreatedAt = DateTime.Now;
                GetDbTable().Add((T)(object)this);
                bool saved = DbContext.SaveChanges() > 0;
            }
            return DbContext.SaveChanges() > 0;
        }

        public bool Delete()
        {
            GetDbTable().Remove((T)(object)this);
            return DbContext.SaveChanges() > 0;
        }

    }
}