using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoServer.Models
{
    public class Task : BaseModel<Task>
    {
        public DateTime? ClosedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public string Headline { get; set; }
        public string Description { get; set; }
        public string State { get; set; }

        public virtual List<Todo> Todos { get; set; }
        public virtual List<int?> TodoIds
        {
            get
            {
                return Todo.All().Where(x => x.TaskId == Id).Select(x => x.Id).ToList();
            }
        }
    }
}