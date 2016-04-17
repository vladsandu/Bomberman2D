using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;
using RenderEngine.Entities;
using RenderEngine.Loader;
using RenderEngine.Maths;
using RenderEngine.Models;

namespace BombermanGame
{
    public class CurrentData
    {

        int windowHeight = 600, windowWidth = 800;

        public Camera Camera { get; set; }
        public Entity Entity { get; set; }
        private Loader loader = new Loader();
        
        float normalizedX, normalizedY;

        public CurrentData()
        {
            initialize();
        }

        private void initialize()
        {
            Camera = new Camera(new Vector3(0, 0, 0), 0);

            ModelTexture playerTexture = new ModelTexture(loader.LoadTexture("./data/WallTile.png"));
            TexturedModel playerModel = new TexturedModel(playerTexture, GLUtils.createRectangle(loader, 5, 2));
            Entity = new Entity(playerModel, new Vector2(0.0f, 0.0f), 0);

        }

        public void resetGame()
        {
            initialize();
        }

    }
}