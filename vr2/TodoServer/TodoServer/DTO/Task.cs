using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoServer.DTO
{
    public class Task
    {
        public string Headline { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}