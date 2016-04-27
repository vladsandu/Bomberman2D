using System;
using System.Drawing;
using RenderEngine;

namespace BombermanCommons.Collision
{
    public class CollisionBox
    {
        private RectangleF BoundingBox { get; set; }

        public CollisionBox(float x, float y, float width, float height)
        {
            float actualHeightHalf = height * Settings.GetAspectRatio() / 100f;
            float actualWidthHalf = width / (100f);

            BoundingBox = new RectangleF(x-actualWidthHalf, y-actualHeightHalf, actualWidthHalf * 2f, actualHeightHalf*2f);
        }

        public CollisionBox(CollisionBox collisionBox)
        {   
            BoundingBox = collisionBox.BoundingBox;
        }

        public CollisionBox Move(float x, float y)
        {
            RectangleF newBox = BoundingBox;
            newBox.Offset(x, y);
            BoundingBox = newBox;
            return this;
        }


        public CollisionBox MoveUp(float movementSpeed)
        {
            Move(0, movementSpeed);
            return this;
        }

        public CollisionBox MoveLeft(float movementSpeed)
        {
            Move(-movementSpeed, 0);
            return this;
        }

        public CollisionBox MoveRight(float movementSpeed)
        {
            Move(movementSpeed, 0);
            return this;
        }

        public CollisionBox MoveDown(float movementSpeed)
        {
            Move(0, -movementSpeed);
            return this;
        }

        public bool Intersects(CollisionBox box)
        {
            return Intersects(box.BoundingBox);
        }

        public bool Intersects(RectangleF box)
        {
            return RectangleF.Intersect(BoundingBox, box) != RectangleF.Empty;
        }
    }
}