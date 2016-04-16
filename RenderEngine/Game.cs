using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace RenderEngine
{
    public class Game : GameWindow
    {
        protected override void OnLoad(EventArgs e)
        {
            this.VSync = VSyncMode.On;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
        }
    }
}