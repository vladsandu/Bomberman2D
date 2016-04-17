using OpenTK;
using RenderEngine.Models;
using RenderEngine.Animations;

namespace RenderEngine.Entities
{
    public class AnimatedEntity : Entity
    {
        private Animation Animation { get; set; }
        public AnimatedEntity(Animation animation, TexturedModel model, Vector2 position, int layer) : base(model, position, layer)
        {
            Animation = animation;
        }

        public virtual void UpdateAnimation()
        {
            Animation.IncreaseFrameCount();
        }
    }
}