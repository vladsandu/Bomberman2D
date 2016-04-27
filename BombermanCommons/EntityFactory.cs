using BombermanCommons;
using BombermanCommons.Entities;
using OpenTK;
using RenderEngine;
using RenderEngine.Animations;
using RenderEngine.Entities;
using RenderEngine.Maths;
using RenderEngine.Models;
using RenderEngine.Renderer;

namespace BombermanCommons
{
    public class EntityFactory
    {
        private Loader _loader;
        private ModelTexture _dirtTexture;
        private ModelTexture _grassTexture;
        private ModelTexture _playerTexture;
        private ModelTexture _bombTexture;
        private ModelTexture _explosionTexture;

        public EntityFactory(Loader loader)
        {
            _loader = loader;
        }

        public void LoadEntities()
        {
            _dirtTexture = new ModelTexture(_loader.LoadTexture("./data/dirtTile.png"));
            _grassTexture = new ModelTexture(_loader.LoadTexture("./data/grassTile.png"));
            _playerTexture = new ModelTexture(_loader.LoadTexture("./data/playerTexture.png"));
            _bombTexture = new ModelTexture(_loader.LoadTexture("./data/bombTexture.png"));
            _explosionTexture = new ModelTexture(_loader.LoadTexture("./data/explosionTexture.png"));
        }

        public Tile GenerateDirtTile(Vector2 position, int size)
        {
            TexturedModel texturedModel = new TexturedModel(_dirtTexture,GLUtils.CreateRectangle(_loader, size, Settings.GetAspectRatio()));
            return new Tile(texturedModel, position, 0, false);
        }

        public Tile GenerateGrassTile(Vector2 position, int size)
        {
            TexturedModel texturedModel = new TexturedModel(_grassTexture, GLUtils.CreateRectangle(_loader, size, Settings.GetAspectRatio()));
            return new Tile(texturedModel, position, 0, true);
        }
        public Player GeneratePlayer(Vector2 position, int size)
        {
            SpriteSheet playerSpriteSheet = new SpriteSheet(102.4f, 128f, 4, 5, 20);
            AnimatedTextureModel playerModel = new AnimatedTextureModel(playerSpriteSheet, _playerTexture, 
                GLUtils.CreateSpriteSheetQuad(_loader, size, size, Settings.GetAspectRatio(), playerSpriteSheet));
            Player player = new Player(playerModel, position, 6, 2);
            return player;
        }
        public Bomb GenerateBomb(Vector2 position, int size)
        {
            SpriteSheet bombSpriteSheet = new SpriteSheet(113.77777f, 113.77777f, 9, 9, 74);
            AnimatedTextureModel bombModel = new AnimatedTextureModel(bombSpriteSheet, _bombTexture,
            GLUtils.CreateSpriteSheetQuad(_loader, size, size, Settings.GetAspectRatio(), bombSpriteSheet));
            Bomb bomb = new Bomb(bombModel, position, 1, 1);
            return bomb;
        }
        public Explosion GenerateExplosion(Vector2 position, int width, int height)
        {
            SpriteSheet explosionSpriteSheet = new SpriteSheet(256f, 256f, 1, 1, 1);
            AnimatedTextureModel explosionModel = new AnimatedTextureModel(explosionSpriteSheet, _explosionTexture,
            GLUtils.CreateSpriteSheetQuad(_loader, width, height, Settings.GetAspectRatio(), explosionSpriteSheet));
            Explosion explosion = new Explosion(explosionModel, position, 30, 4);
            return explosion;
        }
    }
}