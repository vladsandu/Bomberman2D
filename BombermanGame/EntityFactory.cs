using OpenTK;
using RenderEngine.Animations;
using RenderEngine.Entities;
using RenderEngine.Maths;
using RenderEngine.Models;
using RenderEngine.Renderer;

namespace BombermanGame
{
    public class EntityFactory
    {
        private Loader _loader;
       // private AnimatedTextureModel testModel;
      
        public EntityFactory(Loader loader)
        {
            _loader = loader;
        }

        public void LoadEntities()
        {
//            SpriteSheet testSpriteSheet = new SpriteSheet(113.77777f, 113.77777f, 9, 9, 74);
//            ModelTexture playerTexture = new ModelTexture(_loader.LoadTexture("./data/animation.png"));
//            testModel = new AnimatedTextureModel(testSpriteSheet, playerTexture, GLUtils.CreateSpriteSheetQuad(_loader, 20, 20, testSpriteSheet));
        }
//
//        public AnimatedEntity GetTestEntity(Vector2 position)
//        {
//            return new AnimatedEntity(this.testModel, position, MilisToFrames(30), 0);
//        }

        private int MilisToFrames(int milis)
        {
            return milis*60/1000;
        }
    }
}