namespace RenderEngine.Models
{
    public class TexturedModel
    {
        public ModelTexture ModelTexture { get; set; }
        public RawModel RawModel { get; set; }

        public TexturedModel(ModelTexture modelTexture, RawModel rawModel)
        {
            ModelTexture = modelTexture;
            RawModel = rawModel;
        }
    }
}