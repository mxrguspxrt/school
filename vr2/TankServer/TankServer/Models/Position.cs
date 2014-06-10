using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankServer.Models
{
    public class Position
    {
        public int Id { set; get; }
        public int X { set; get; }
        public int Y { set; get; }
        public int Z { set; get; }
        public int XRotation { set; get; }
        public int YRotation { set; get; }
        public int ZRotation { set; get; }

        public Position()
        {
            this.X = this.Y = this.Z = this.XRotation = this.YRotation = this.ZRotation = 0;
        }
    }
}