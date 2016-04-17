﻿using System;
using System.Drawing;
using BombermanGame;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using RenderEngine.Entities;
using RenderEngine.Renderer;

namespace RenderEngine
{
    public class Game : GameWindow
    {
        private MasterRenderer Renderer { get; set; }
        private Loader Loader { get; set; }
        private CurrentData CurrentData { get; set; }
        private EntityFactory EntityFactory { get; set; }

        public Game()
        {
            Loader = new Loader();
            Renderer = new MasterRenderer();
            EntityFactory = new EntityFactory(Loader);
            CurrentData = new CurrentData(EntityFactory);
        }
        
        protected override void OnLoad(EventArgs e)
        {
            this.VSync = VSyncMode.On;
            EntityFactory.LoadEntities();
            CurrentData.Initialize();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            foreach (AnimatedEntity entity in CurrentData.entities)
            {
                entity.UpdateAnimation();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Renderer.Prepare();
            foreach (AnimatedEntity entity in CurrentData.entities)
            {
                Renderer.ProcessEntity(entity);
            }
            Renderer.Render(CurrentData.Camera);
            SwapBuffers();
          }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
        }
    }
}