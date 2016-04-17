using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK;
using RenderEngine.Entities;
using RenderEngine.Maths;
using RenderEngine.Models;
using RenderEngine.Shaders;

namespace RenderEngine.Renderer
{
    public class Renderer
    {
        private DefaultShader shader;

        public Renderer(DefaultShader shader)
        {

            this.shader = shader;
        }

        public void render(Dictionary<TexturedModel, List<Entity>> entities)
        {

            bool modelCheck;

            for (int i = 0; i < 12; i++)
            { //maxLayers

                foreach (TexturedModel model in entities.Keys)
                {

                    List<Entity> batch = entities[model]; //pentru modelul ala luam continutul adica lista entitatilor

                    modelCheck = false;

                    foreach (Entity entity in batch)
                    {
                        if (entity.Layer == i)
                        {
                            modelCheck = true;
                            break;
                        }
                    }

                    if (modelCheck)
                        prepareTexturedModel(model);
                    else
                        continue;

                    foreach (Entity entity in batch)
                    {
                        if (entity.Layer == i)
                        {
                            prepareInstance(entity); //randam fiecare entitate din lista continuta pt fiecare texturedModel
                            GL.DrawElements(BeginMode.Triangles, model.RawModel.VertexCount, DrawElementsType.UnsignedInt, 0);
                        }
                    }

                    unbindTexturedModel();
                }
            }

        }
        private void prepareTexturedModel(TexturedModel model)
        { //va binda textura + shiny

            RawModel rawModel = model.RawModel; //inca avem nevoie de rawModel pentru vertexuri

            GL.BindVertexArray(rawModel.VaoID);
            GL.EnableVertexAttribArray(0); //asta-i array-ul de atribute 0 unde e primul vbo cu pozitii
            GL.EnableVertexAttribArray(1); //texturi

            GL.ActiveTexture(TextureUnit.Texture0); //facem una din texturile din memoria placii video active
            GL.BindTexture(TextureTarget.Texture2D, model.ModelTexture.TextureID); //bindam la acea textura, textura noastra folosind id-ul ei. e ca un buffer default al placii la care bindam un alt buffer

        }

        private void unbindTexturedModel()
        {  //unbindarea modelului curent

            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.DisableVertexAttribArray(2);
            GL.BindVertexArray(0);

        }

        private void prepareInstance(Entity entity)
        { //matricea de transformare si incarcarea ei pentru fiecare entitate
            Matrix4 transformationMatrix = GLUtils.createTransformationMatrix(entity.Position.Yx, entity.RotZ, entity.Scale);

            shader.loadTransformationMatrix(transformationMatrix);
            shader.loadXOffset(entity.XOffset);
            shader.loadYOffset(entity.YOffset);
        }

    }
}