using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using RenderEngine;
using BombermanCommons.Collision;

namespace BombermanCommons.Entities
{
    public class MapRegion
    {
        private RectangleF BoundingBox { get; set; }
        public List<Tile> Tiles { get; set; }
         
        public MapRegion(Vector2 position, float width, float height, int size)
        {
            float actualHeightHalf = height * Settings.GetAspectRatio() / 100f;
            float actualWidthHalf = width / (100f);
            
            BoundingBox = new RectangleF(position.X - actualWidthHalf, position.Y - actualHeightHalf - size, size, size + actualHeightHalf * 2f);
            Tiles = new List<Tile>();
        }

        public void AddTile(Tile dirtTile)
        {
            Tiles.Add(dirtTile);
        }

        public bool Contains(CollisionBox collisionBox)
        {
            return collisionBox.Intersects(BoundingBox);
        }
    }
}