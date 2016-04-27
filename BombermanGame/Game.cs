using System;
using System.Drawing;
using BombermanGame;
using BombermanGame.Input;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using RenderEngine.Entities;
using RenderEngine.Renderer;
using BombermanGame.Network;
using System.Threading;
using BombermanCommons.Collision;
using BombermanCommons.Entities;
using BombermanCommons;

namespace RenderEngine
{
    public class Game : GameWindow
    {
        private MasterRenderer Renderer { get; set; }
        private Loader Loader { get; set; }
        private CurrentData CurrentData { get; set; }
        private EntityFactory EntityFactory { get; set; }
        private KeyboardListener KeyboardListener { get; set; }
        private CollisionDetector CollisionDetector { get; set; }
        private NetHandler NetHandler { get; set; }
        
        public Game()
        {
            Loader = new Loader();
            Renderer = new MasterRenderer();
            EntityFactory = new EntityFactory(Loader);
            CurrentData = new CurrentData(EntityFactory);
            CollisionDetector = new CollisionDetector(CurrentData);
            NetHandler = new NetHandler(CurrentData);
            KeyboardListener = new KeyboardListener(CurrentData, NetHandler, CollisionDetector);
            ThreadStart netThreadStart = NetHandler.Connect;
            Thread netThread = new Thread(netThreadStart);
            netThread.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.VSync = VSyncMode.On;
            EntityFactory.LoadEntities();
            CurrentData.Initialize();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardListener.ListenKeyboardEvents();
            UpdateCameraPosition();
            UpdateAnimations();
            UpdateFinishedBombs();
            UpdateFinishedExplosions();
            ProcessExplosionCollisions();
        }

        private void ProcessExplosionCollisions()
        {
            if (CollisionDetector.IsCollidingExplosions(CurrentData.LocalPlayer))
            {
                Console.WriteLine("Player 1 has lost.");
            }
        }

        private void UpdateFinishedExplosions()
        {
            for (int i = CurrentData.Explosions.Count - 1; i >= 0; i--)
            {
                if (CurrentData.Explosions[i].IsAnimationFinished())
                    CurrentData.Explosions.RemoveAt(i);
            }
        }

        private void UpdateFinishedBombs()
        {
            for (int i = CurrentData.Bombs.Count - 1; i >= 0; i--)
            {
                if (CurrentData.Bombs[i].IsAnimationFinished())
                {
                    CurrentData.AddExplosions(CurrentData.Bombs[i].Position);
                    CurrentData.Bombs.RemoveAt(i);
                }
            }
        }

        private void UpdateAnimations()
        {
            foreach (Bomb bomb in CurrentData.Bombs)
            {
                bomb.UpdateAnimation();
            }
            foreach (AnimatedEntity explosion in CurrentData.Explosions)
            {
                explosion.UpdateAnimation();
            }
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
            RenderBombs();
            RenderExplosions();
            Renderer.Render(CurrentData.Camera);
            SwapBuffers();
          }

        private void RenderPlayers()
        {
            Renderer.ProcessEntity(CurrentData.LocalPlayer);
        }
        private void RenderBombs()
        {
            foreach (Bomb bomb in CurrentData.Bombs)
            {
                Renderer.ProcessEntity(bomb);
            }
        }
        private void RenderExplosions()
        {
            foreach (AnimatedEntity explosion in CurrentData.Explosions)
            {
                Renderer.ProcessEntity(explosion);
            }
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
            Settings.WIDTH = Width;
            Settings.HEIGHT = Height;
        }
    }
}