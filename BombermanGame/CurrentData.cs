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
        public List<AnimatedEntity> entities = new List<AnimatedEntity>(); 
        public CurrentData(EntityFactory entityFactory)
        {
            EntityFactory = entityFactory;
        }

        public void Initialize()
        {
            Camera = new Camera(new Vector3(0, 0, 0), 0);
    //        entities.Add(EntityFactory.GetTestEntity(new Vector2(0,0)));
        }
    }
}