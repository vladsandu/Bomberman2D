using System;
using System.Drawing;
using BombermanGame;
using BombermanGame.Input;
using BombermanGame.Entities;
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
        private KeyboardListener KeyboardListener { get; set; }
        public static float WIDTH, HEIGHT ;

        public static float GetAspectRatio()
        {
            return WIDTH/HEIGHT;
        }
        public Game()
        {
            Loader = new Loader();
            Renderer = new MasterRenderer();
            EntityFactory = new EntityFactory(Loader);
            CurrentData = new CurrentData(EntityFactory);
            KeyboardListener = new KeyboardListener(CurrentData);
        }
        
        protected override void OnLoad(EventArgs e)
        {
            WIDTH = Width;
            HEIGHT = Height;
            this.VSync = VSyncMode.On;
            EntityFactory.LoadEntities();
            CurrentData.Initialize();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardListener.ListenKeyboardEvents();
            UpdateCameraPosition();
        }

        private void UpdateCameraPosition()
        {
            CurrentData.Camera.SetPosition(CurrentData.LocalPlayer.Position);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Renderer.Prepare();
            RenderMap();
            RenderPlayers();
            Renderer.Render(CurrentData.Camera);
            SwapBuffers();
          }

        private void RenderPlayers()
        {
            Renderer.ProcessEntity(CurrentData.LocalPlayer);
        }

        private void RenderMap()
        {
            foreach (MapRegion region in CurrentData.Map.Regions)
            {
                foreach (Tile tile in region.Tiles)
                {
                    Renderer.ProcessEntity(tile);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);
            WIDTH = Width;
            HEIGHT = Height;
        }
    }
}