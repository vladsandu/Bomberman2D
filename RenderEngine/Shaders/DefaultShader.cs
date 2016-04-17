﻿using System;
using OpenTK;
using RenderEngine.Entities;

namespace RenderEngine.Shaders
{
    public class DefaultShader : ShaderProgram
    {

        private static String VERTEX_FILE = "src/shaders/vertexShader.glsl";
	    private static String FRAGMENT_FILE = "src/shaders/fragmentShader.glsl";
	
	private int location_transformationMatrix;
        private int location_viewMatrix;
        private int location_isBackground;
        private int location_isText;
        private int location_xOffset;
        private int location_yOffset;

        public DefaultShader()
            : base(VERTEX_FILE, FRAGMENT_FILE)
        {
            
        }

        protected void bindAttributes()
        {

            base.bindAttribute(0, "positions"); //bindam la variabila positions folosita in vertexshader ce se afla in vao-ul curent la atributul 0 adica VBO-ul de pozitii ale vertexurilor
            base.bindAttribute(1, "textureCoords");
        }

        protected void getAllUniformLocations()
        {
            location_transformationMatrix = base.GetUniformLocation("transformationMatrix");
            location_viewMatrix = base.GetUniformLocation("viewMatrix");
            location_isBackground = base.GetUniformLocation("isBackground");
            location_isText = base.GetUniformLocation("isText");
            location_xOffset = base.GetUniformLocation("xOffset");
            location_yOffset = base.GetUniformLocation("yOffset");
        }

        public void loadXOffset(float value)
        {
            base.LoadFloat(location_xOffset, value);
        }

        public void loadYOffset(float value)
        {
            base.LoadFloat(location_yOffset, value);
        }
        
        public void loadTransformationMatrix(Matrix4 matrix)
        {
            base.LoadMatrix(location_transformationMatrix, matrix);
        }

        public void loadViewMatrix(Camera camera)
        {
            Matrix4 matrix = Maths.createViewMatrix(camera);
            LoadMatrix(location_viewMatrix, matrix);
        }

    }
}