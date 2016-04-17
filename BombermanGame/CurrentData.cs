using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;
using RenderEngine.Entities;
using RenderEngine.Renderer;
using RenderEngine.Maths;
using RenderEngine.Models;

namespace BombermanGame
{
    public class CurrentData
    {
        private EntityFactory EntityFactory { get; set; }
        public Camera Camera { get; set; }
        
        public CurrentData(EntityFactory entityFactory)
        {
            EntityFactory = entityFactory;
        }

        public void Initialize()
        {
            Camera = new Camera(new Vector3(0, 0, 0), 0);

//            ModelTexture playerTexture = new ModelTexture(loader.LoadTexture("./data/WallTile.png"));
//            TexturedModel playerModel = new TexturedModel(playerTexture, GLUtils.createRectangle(loader, 5, 2));
//            Entity = new Entity(playerModel, new Vector2(0.0f, 0.0f), 0);
        }
    }
}