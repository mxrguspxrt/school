using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoServer.DTO
{
    public class Todo
    {
        public string Headline { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}