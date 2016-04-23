using BombermanGame.Entities;
using OpenTK;
using RenderEngine;
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
        private ModelTexture _dirtTexture;
        private ModelTexture _grassTexture;
        private ModelTexture _playerTexture;

        public EntityFactory(Loader loader)
        {
            _loader = loader;
        }

        public void LoadEntities()
        {
//            SpriteSheet testSpriteSheet = new SpriteSheet(113.77777f, 113.77777f, 9, 9, 74);
              _dirtTexture = new ModelTexture(_loader.LoadTexture("./data/dirtTile.png"));
              _grassTexture = new ModelTexture(_loader.LoadTexture("./data/grassTile.png"));
            _playerTexture = new ModelTexture(_loader.LoadTexture("./data/playerTexture.png"));
            //            testModel = new AnimatedTextureModel(testSpriteSheet, playerTexture, GLUtils.CreateSpriteSheetQuad(_loader, 20, 20, testSpriteSheet));
        }
        //
        //        public AnimatedEntity GetTestEntity(Vector2 position)
        //        {
        //            return new AnimatedEntity(this.testModel, position, MilisToFrames(30), 0);
        //        }

        public Tile GetDirtTile(Vector2 position, int size)
        {
            TexturedModel texturedModel = new TexturedModel(_dirtTexture,GLUtils.CreateRectangle(_loader, size, Game.GetAspectRatio()));
            return new Tile(texturedModel, position, 0, false);
        }

        public Tile GetGrassTile(Vector2 position, int size)
        {
            TexturedModel texturedModel = new TexturedModel(_grassTexture, GLUtils.CreateRectangle(_loader, size, Game.GetAspectRatio()));
            return new Tile(texturedModel, position, 0, true);
        }

        public Player GetPlayer(Vector2 position, int size)
        {
            SpriteSheet playerSpriteSheet = new SpriteSheet(102.4f, 128f, 4, 5, 20);
            AnimatedTextureModel playerModel = new AnimatedTextureModel(playerSpriteSheet, _playerTexture, 
                GLUtils.CreateSpriteSheetQuad(_loader, size, size, Game.GetAspectRatio(), playerSpriteSheet));
            Player player = new Player(playerModel, position, 6, 1);
            return player;
        }

        private int MilisToFrames(int milis)
        {
            return milis*60/1000;
        }
    }
}