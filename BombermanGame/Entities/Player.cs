using BombermanGame.Collision;
using OpenTK;
using RenderEngine.Entities;
using RenderEngine.Models;

namespace BombermanGame.Entities
{
    public class Player : AnimatedEntity
    {
        private const float _movementSpeed = 0.01f;
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
            IncreasePosition(0, _movementSpeed);
            _spriteRow = 0;
        }

        public void moveLeft()
        {
            IncreasePosition(-_movementSpeed, 0);
            _spriteRow = 2;
        }

        public void moveRight()
        {
            IncreasePosition(_movementSpeed, 0);
            _spriteRow = 3;
        }

        public void moveDown()
        {
            IncreasePosition(0, -_movementSpeed);
            _spriteRow = 1;
        }

        public void SetPosition(float x, float y)
        {
            
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