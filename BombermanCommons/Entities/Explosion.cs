using BombermanCommons.Collision;
using OpenTK;
using RenderEngine.Entities;
using RenderEngine.Models;

namespace BombermanCommons.Entities
{
    public class Explosion : AnimatedEntity
    {
        public CollisionBox CollisionBox { get; set; }
        public Explosion(AnimatedTextureModel model, Vector2 position, int frameSpeed, int layer) : base(model, position, frameSpeed, layer)
        {
            CollisionBox = GenerateCollisionBox();
        }

        private CollisionBox GenerateCollisionBox()
        {
            return new CollisionBox(Position.X, Position.Y, Width, Height);
        }
    }
}