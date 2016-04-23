using System.Collections.Generic;
using OpenTK;

namespace BombermanGame.Entities
{
    public class MapRegion
    {
        public Vector2 StartCoordinate { get; set; }
        public int Size { get; set; }
        public List<Tile> Tiles { get; set; }
         
        public MapRegion(Vector2 startCoordinate, int size)
        {
            StartCoordinate = startCoordinate;
            Size = size;
            Tiles = new List<Tile>();
        }

        public void AddTile(Tile dirtTile)
        {
            Tiles.Add(dirtTile);
        }

        public bool Contains(Vector2 position)
        {
            return position.X >= StartCoordinate.X && position.X <= StartCoordinate.X + Size &&
                   position.Y <= StartCoordinate.Y && position.Y >= StartCoordinate.Y - Size;
        }
    }
}