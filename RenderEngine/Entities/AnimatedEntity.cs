using System;
using OpenTK;   
using RenderEngine.Models;
using RenderEngine.Animations;

namespace RenderEngine.Entities
{
    public class AnimatedEntity : Entity
    {
        private Animation Animation { get; set; }

        public AnimatedEntity(Animation animation, TexturedModel model, Vector2 position, int layer)
            : base(model, position, layer)
        {
            Animation = animation;
        }

        public virtual void UpdateAnimation()
        {
            Animation.IncreaseFrameCount();
            if (Animation.IsNewSprite())
            {
                UpdateTextureOffsets();
            }
        }

        private void UpdateTextureOffsets()
        {
            int xPoz = Animation.CurrentSpriteNumber%Animation.SpriteSheet.Cols;
            int yPoz = Animation.CurrentSpriteNumber/Animation.SpriteSheet.Cols;
            XOffset = (float) (xPoz*Animation.SpriteSheet.SpriteSizeX)/(float) Animation.SpriteSheet.ImageWidth;
            YOffset = (float) (yPoz*Animation.SpriteSheet.SpriteSizeY)/(float) Animation.SpriteSheet.ImageHeight;
        }
    }
}