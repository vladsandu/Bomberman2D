using BombermanGame.Collision;
using OpenTK;
using OpenTK.Graphics.ES10;
using RenderEngine.Entities;
using RenderEngine.Models;

namespace BombermanGame.Entities
{
    public class Tile : Entity
    {
        public bool Walkable { get; set; }
        public CollisionBox CollisionBox { get; set; }

        public Tile(TexturedModel model, Vector2 position, int layer, bool isWalkable) : base(model, position, layer)
        {
            Walkable = isWalkable;
            CollisionBox = GenerateCollisionBox();
        }

        private CollisionBox GenerateCollisionBox()
        {
            return new CollisionBox(Position.X, Position.Y, Width, Height);
        }
    }
}