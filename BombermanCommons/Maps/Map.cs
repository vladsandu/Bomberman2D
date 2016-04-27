using System.Collections.Generic;

namespace BombermanCommons.Entities
{
    public class Map
    {
        public List<MapRegion> Regions { get; set; }
        
        public Map()
        {
            Regions = new List<MapRegion>();
        }

        public void AddTile(Tile dirtTile)
        {
            foreach (MapRegion region in Regions)
            {
                if (region.Contains(dirtTile.CollisionBox))
                {
                    region.AddTile(dirtTile);
                    return;
                }
            }
            MapRegion newRegion = new MapRegion(dirtTile.Position, dirtTile.Width, dirtTile.Height, 10000);
            newRegion.AddTile(dirtTile);
            Regions.Add(newRegion);
        }
    }
}