using OpenTK;
using RenderEngine.Entities;
using RenderEngine.Models;

namespace BombermanCommons.Entities
{
    public class Bomb : AnimatedEntity
    {
        public Bomb(AnimatedTextureModel model, Vector2 position, int frameSpeed, int layer) : base(model, position, frameSpeed, layer)
        {
        }
    }
}