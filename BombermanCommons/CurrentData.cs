using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;
using RenderEngine.Entities;
using RenderEngine.Renderer;
using RenderEngine.Maths;
using RenderEngine.Models;
using BombermanCommons.Entities;

namespace BombermanCommons
{
    public class CurrentData
    {
        private EntityFactory EntityFactory { get; set; }
        public Camera Camera { get; set; }
        public List<Bomb> Bombs = new List<Bomb>();
        public List<Explosion> Explosions = new List<Explosion>();
        public Map Map { get; set; }
        public Player LocalPlayer { get; set; }
        public CurrentData(EntityFactory entityFactory)
        {
            EntityFactory = entityFactory;
        }

        public void Initialize()
        {
            Camera = new Camera(new Vector3(1, -1, 0), 0);
            Map = new MapLoader(EntityFactory).GenerateMap("./data/map.bmb", 10);
            LocalPlayer = EntityFactory.GeneratePlayer(new Vector2(1, -1.5f), 8);
            //        entities.Add(EntityFactory.GetTestEntity(new Vector2(0,0)));
        }

        public void AddBomb(Vector2 position)
        {
            Bombs.Add(EntityFactory.GenerateBomb(position, 10));
        }
        public void AddExplosions(Vector2 position)
        {
            Explosions.Add(EntityFactory.GenerateExplosion(position, 70, 8));
            Explosions.Add(EntityFactory.GenerateExplosion(position, 8, 70));
            //the width and height has to be based on the actual map block positions
        }
    }
}