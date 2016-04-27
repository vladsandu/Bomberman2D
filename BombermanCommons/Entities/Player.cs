using BombermanCommons.Collision;
using OpenTK;
using RenderEngine.Entities;
using RenderEngine.Models;

namespace BombermanCommons.Entities
{
    public class Player : AnimatedEntity
    {
        public float MovementSpeed = 0.015f;
        private int _spriteRow;
        private int _spriteCount = 0;
        public CollisionBox CollisionBox { get; set; }

        public Player(AnimatedTextureModel model, Vector2 position, int frameSpeed, int layer) : base(model, position, frameSpeed, layer)
        {
            CollisionBox = GenerateCollisionBox();
        }

        private CollisionBox GenerateCollisionBox()
        {
            return new CollisionBox(Position.X, Position.Y, Width, Height);
        }


        public void moveUp()
        {
            IncreasePosition(0, MovementSpeed);
            _spriteRow = 0;
        }

        public void moveLeft()
        {
            IncreasePosition(-MovementSpeed, 0);
            _spriteRow = 2;
        }

        public void moveRight()
        {
            IncreasePosition(MovementSpeed, 0);
            _spriteRow = 3;
        }

        public void moveDown()
        {
            IncreasePosition(0, -MovementSpeed);
            _spriteRow = 1;
        }

        public override void IncreasePosition(float dx, float dy)
        {
            base.IncreasePosition(dx, dy);
            CollisionBox.Move(dx, dy);
        }

        public override void UpdateAnimation()
        {
            Animation.IncreaseFrameCount();
            if (Animation.IsNewSprite())
            {
                Animation.CurrentSpriteNumber = _spriteRow * (Animation.SpriteSheet.Cols) + _spriteCount++;
                
                if (_spriteCount == Animation.SpriteSheet.Cols - 1 ||
                    Animation.CurrentSpriteNumber + 1 == Animation.SpriteSheet.SpriteNumber)
                    _spriteCount = 0;
                
                UpdateTextureOffsets();
            }
        }
    }
}