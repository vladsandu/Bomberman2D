using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using RenderEngine.Entities;
using RenderEngine.Models;
using RenderEngine.Shaders;

namespace RenderEngine.Renderer
{
    public class MasterRenderer
    {
        private DefaultShader _shader = new DefaultShader();
        private Renderer _renderer;

        private const int RED = 0, BLUE = 0, GREEN = 0;

        public MasterRenderer()
        {
            _renderer = new Renderer(_shader);
        }

        private Dictionary<TexturedModel, List<Entity>> entities = new Dictionary<TexturedModel, List<Entity>>();

        public void Render(Camera camera)
        {

            Prepare();
            _shader.Start();
            _shader.LoadViewMatrix(camera);
            _renderer.Render(entities); //randam tot hashmapul de entitati in functie de texturedModels LA FIECARE FRAME
            _shader.Stop();
            entities.Clear();
        }

        public void ProcessEntity(Entity entity)
        {

            TexturedModel entityModel = entity.Model;
            List<Entity> batch;
            if (!entities.TryGetValue(entityModel, out batch))
            {
                //daca nu exista inca un key cu texturedModelul curent
                List<Entity> newBatch = new List<Entity>();
                entities.Add(entityModel, newBatch);
                entities[entityModel].Add(entity);

            }
            else
            {
                entities[entityModel].Add(entity);
            }

        }

        public void CleanUp()
        { //curatenie. sterge shaderele care inainte erau sterse in MainGameLoop
            _shader.CleanUp();
        }

        public void Prepare()
        {

            GL.ClearColor(RED, GREEN, BLUE, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit); //tre sa golim ambele buffere la fiecare frame
        }

    }
}