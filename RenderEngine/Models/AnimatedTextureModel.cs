using RenderEngine.Animations;

namespace RenderEngine.Models
{
    public class AnimatedTextureModel : TexturedModel
    {
        public SpriteSheet SpriteSheet { get; set; }
        public AnimatedTextureModel(SpriteSheet spriteSheet, ModelTexture modelTexture, RawModel rawModel) : base(modelTexture, rawModel)
        {
            SpriteSheet = spriteSheet;
        }
    }
}