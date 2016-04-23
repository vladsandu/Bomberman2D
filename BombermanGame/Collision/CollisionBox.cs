using System.Drawing;
using RenderEngine;

namespace BombermanGame.Collision
{
    public class CollisionBox
    {
        private RectangleF BoundingBox { get; set; }

        public CollisionBox(float x, float y, float width, float height)
        {
            float actualHeightHalf = height * Game.GetAspectRatio() / 100f;
            float actualWidthHalf = width / (100f);

            BoundingBox = new RectangleF(x-actualWidthHalf, y+actualHeightHalf, actualWidthHalf * 2f, actualHeightHalf*2f);
        }

        public void Move(float x, float y)
        {
            BoundingBox.Offset(x, y);
        }

        public bool Intersects(CollisionBox box)
        {
            return BoundingBox.IntersectsWith(box.BoundingBox);
        }
    }
}