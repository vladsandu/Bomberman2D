using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using RenderEngine.Entities;
using RenderEngine.Models;
using RenderEngine.Shaders;

namespace RenderEngine.Renderer
{
    public class MasterRenderer
    {
        private DefaultShader shader = new DefaultShader();
        private Renderer renderer;

        private const int RED = 0, BLUE = 0, GREEN = 0;

        public MasterRenderer()
        {
            renderer = new Renderer(shader);
        }

        private Dictionary<TexturedModel, List<Entity>> entities = new Dictionary<TexturedModel, List<Entity>>();

        public void render(Camera camera)
        {

            prepare();
            shader.Start();
            shader.loadViewMatrix(camera);
            renderer.render(entities); //randam tot hashmapul de entitati in functie de texturedModels LA FIECARE FRAME
            shader.Stop();
            entities.Clear();
        }

        public void processEntity(Entity entity)
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

        public void cleanUp()
        { //curatenie. sterge shaderele care inainte erau sterse in MainGameLoop
            shader.CleanUp();
        }

        public void prepare()
        {

            GL.ClearColor(RED, GREEN, BLUE, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit); //tre sa golim ambele buffere la fiecare frame
        }

    }
}