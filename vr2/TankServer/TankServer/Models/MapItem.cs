using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankServer.Models
{
    public class MapItem
    {
        public int Id { get; set; }
        public string MapItemType { get; set; }
        public virtual Position Position { get; set; }

        public MapItem()
        {
        }
    }
}