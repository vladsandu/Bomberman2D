using System.Collections.Generic;
using BombermanGame.Entities;
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
        public List<AnimatedEntity> entities = new List<AnimatedEntity>();
        public Map Map { get; set; }
        public Player LocalPlayer { get; set; }
        public CurrentData(EntityFactory entityFactory)
        {
            EntityFactory = entityFactory;
        }

        public void Initialize()
        {
            Camera = new Camera(new Vector3(1, -1, 0), 0);
            Map = new MapLoader(EntityFactory).GenerateMap("./data/map.bmb", 15);
            LocalPlayer = EntityFactory.GetPlayer(new Vector2(1, -1.5f), 15);
            //        entities.Add(EntityFactory.GetTestEntity(new Vector2(0,0)));
        }
    }
}