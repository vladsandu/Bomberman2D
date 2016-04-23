using System.Collections.Generic;

namespace BombermanGame.Entities
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
                if (region.Contains(dirtTile.Position))
                {
                    region.AddTile(dirtTile);
                    return;
                }
            }
            MapRegion newRegion = new MapRegion(dirtTile.Position, 1000);
            newRegion.AddTile(dirtTile);
            Regions.Add(newRegion);
        }
    }
}