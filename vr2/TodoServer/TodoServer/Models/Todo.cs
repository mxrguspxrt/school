using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoServer.Models
{
    public class Todo : BaseModel<Todo>
    {
        public DateTime? DeadlineAt { get; set; }        
        public bool? IsDeleted { get; set; }

        public string Headline { get; set; }
        public string Description { get; set; }
        public string State { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }


    }
}