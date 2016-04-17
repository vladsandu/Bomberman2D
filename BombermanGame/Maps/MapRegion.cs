using OpenTK;

namespace BombermanGame.Maps
{
    public class MapRegion
    {
        public Vector2 StartCoordinate { get; set; }
        public int Size { get; set; }
        public MapRegion(Vector2 startCoordinate, int size)
        {
            StartCoordinate = startCoordinate;
            Size = size;
        }
    }
}