using System;
using System.Drawing;
using BombermanGame;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using RenderEngine.Renderer;

namespace RenderEngine
{
    public class Game : GameWindow
    {
        private MasterRenderer Renderer { get; set; }
        private CurrentData CurrentData { get; set; }
        public Game()
        {
            Renderer = new MasterRenderer();
            CurrentData = new CurrentData();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            this.VSync = VSyncMode.On;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            CurrentData.Entity.IncreasePosition(0.01f, 0);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Renderer.prepare();
            Renderer.processEntity(CurrentData.Entity);
            Renderer.render(CurrentData.Camera);
            SwapBuffers();
          }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
        }
    }
}