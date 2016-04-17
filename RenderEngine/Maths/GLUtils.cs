using System;
using OpenTK;
using RenderEngine.Entities;
using RenderEngine.Models;
using RenderEngine.Renderer;

namespace RenderEngine.Maths
{
    public class GLUtils
    {
        public static Matrix4 createTransformationMatrix(Vector2 translation, float rz, float scale)
        {

            Matrix4 matrix = Matrix4.Identity;
            Matrix4.CreateTranslation(translation.X, translation.Y, 0, out matrix);
            Matrix4.CreateRotationZ(0, out matrix);
            Matrix4.CreateScale(scale, out matrix);

            return matrix;
        }

        public static Matrix4 createViewMatrix(Camera camera)
        {
            Matrix4 viewMatrix = Matrix4.Identity;
            Vector3 cameraPos = camera.getPosition();
            Vector3 negativeCameraPos = new Vector3(-cameraPos.X, -cameraPos.Y, -cameraPos.Z);
            Matrix4.CreateTranslation(ref negativeCameraPos, out viewMatrix);

            return viewMatrix;

        }


        public static RawModel CreateSpriteSheetQuad(Loader loader, float widthPercent, float heightPercent,
                float spriteSizeX, float spriteSizeY, float imageWidth, float imageHeight)
        {

            //lengthPercent & widthPercent - se refera la cat % din ecran sa fie de mare

            float actualHeightHalf = heightPercent / 100;
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
                0,spriteSizeY/imageHeight,
                spriteSizeX/imageWidth,spriteSizeY/imageHeight,
                spriteSizeX/imageWidth,0
        };


            return loader.LoadToVAO(vertices, textureCoords, indices, widthPercent, heightPercent);
        }

        public static RawModel createQuadPercentTextured(Loader loader, float widthPercent, float heightPercent,
                float xTexPercent, float yTexPercent)
        {

            float actualHeightHalf = heightPercent / 100;
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
                0,1 * yTexPercent/100f,
                1 * xTexPercent/100f,1 * yTexPercent/100f,
                1 * xTexPercent/100f,0
        };


            return loader.LoadToVAO(vertices, textureCoords, indices, widthPercent, heightPercent);

        }

        public static RawModel createRectangle(Loader loader, float widthPercent, float heightPercent)
        {

            float actualHeightHalf = heightPercent / 100;
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
                0,1,
                1,1,
                1,0
        };


            return loader.LoadToVAO(vertices, textureCoords, indices, widthPercent, heightPercent);
        }
    }
}