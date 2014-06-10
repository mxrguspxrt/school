using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankServer.Models
{
    public class Map
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public virtual List<MapItem> MapItems { get; set; }

        public Map()
        {
            this.MapItems = new List<MapItem>();
        }

        public static Map Generate(int W, int H)
        {
            Map map = new Map() { Width = W, Height = H };
            // create grass
            for (int i = 0; i < H; i=i+100)
            {
                for (int j = 0; j < W; j=j+100)
                {
                    Position position = new Position() { X=j, Y=i };
                    MapItem mapItem = new MapItem() { Position=position, MapItemType="grass" };
                    map.MapItems.Add(mapItem);
                }
            }
            // return map
            return map;
        }
    }
}