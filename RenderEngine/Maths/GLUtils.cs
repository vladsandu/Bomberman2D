using System;
using OpenTK;
using RenderEngine.Animations;
using RenderEngine.Entities;
using RenderEngine.Models;
using RenderEngine.Renderer;

namespace RenderEngine.Maths
{
    public class GLUtils
    {
        public static Matrix4 CreateTransformationMatrix(float x, float y, float rz, float scale)
        {

            Matrix4 matrix = Matrix4.Identity;
            Matrix4.CreateTranslation(x, y, 0, out matrix);
         //   Matrix4.CreateRotationZ(0, out matrix);
           // Matrix4.CreateScale(scale, out matrix);

            return matrix;
        }

        public static Matrix4 CreateViewMatrix(Camera camera)
        {
            Matrix4 viewMatrix = Matrix4.Identity;
            Vector3 cameraPos = camera.GetPosition();
            Vector3 negativeCameraPos = new Vector3(-cameraPos.X, -cameraPos.Y, -cameraPos.Z);
            Matrix4.CreateTranslation(ref negativeCameraPos, out viewMatrix);

            return viewMatrix;

        }


        public static RawModel CreateSpriteSheetQuad(Loader loader, float widthPercent, float heightPercent, float aspectRatio,
                SpriteSheet spriteSheet)
        {

            //lengthPercent & widthPercent - se refera la cat % din ecran sa fie de mare

            float actualHeightHalf = heightPercent * aspectRatio / 100;
            float actualWidthHalf = widthPercent / 100;

            float[] vertices ={
                    -actualWidthHalf, actualHeightHalf, 0.0f,
                    -actualWidthHalf, -actualHeightHalf, 0.0f,
                    actualWidthHalf, -actualHeightHalf, 0.0f,
                    actualWidthHalf, actualHeightHalf, 0.0f,
            };

            int[] indices = { 0, 1, 3, 3, 1, 2 };
            
            float[] textureCoords = {
                0,0,
                0,spriteSheet.SpriteSizeY/spriteSheet.ImageHeight,
                spriteSheet.SpriteSizeX/spriteSheet.ImageWidth,spriteSheet.SpriteSizeY/spriteSheet.ImageHeight,
                spriteSheet.SpriteSizeX/spriteSheet.ImageWidth,0
        };


            return loader.LoadToVAO(vertices, textureCoords, indices, widthPercent, heightPercent);
        }
        
        public static RawModel CreateRectangle(Loader loader, float size, float aspectRatio)
        {

            float actualHeightHalf = size * aspectRatio/100f;
            float actualWidthHalf = size /( 100f);
            
            float[] vertices ={
                    -actualWidthHalf, actualHeightHalf, 0.0f,
                    -actualWidthHalf, -actualHeightHalf, 0.0f,
                    actualWidthHalf, -actualHeightHalf, 0.0f,
                    actualWidthHalf, actualHeightHalf, 0.0f,
            };

            int[] indices = { 0, 1, 3, 3, 1, 2 };

            float[] textureCoords = {
                0,0,
                0,1,
                1,1,
                1,0
        };


            return loader.LoadToVAO(vertices, textureCoords, indices, size, size);
        }
    }
}