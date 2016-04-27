using System;
using BombermanCommons.Entities;
using OpenTK;
using OpenTK.Input;
using BombermanGame.Network;
using BombermanCommons.Collision;
using BombermanCommons;

namespace BombermanGame.Input
{
    public class KeyboardListener
    {
        private NetHandler NetHandler { get; set; }
        private CollisionDetector CollisionDetector { get; set; }
        private CurrentData CurrentData { get; set; }
        public KeyboardListener(CurrentData currentData, NetHandler netHandler, CollisionDetector collisionDetector)
        {
            CollisionDetector = collisionDetector;
            NetHandler = netHandler;
            CurrentData = currentData;
        }

        public void ListenKeyboardEvents()
        {
            // get the combined state of all keyboard devices:
            var state = OpenTK.Input.Keyboard.GetState();
            bool moving = false;
            CollisionBox newBox;
            if (state[Key.Up])
            {
                newBox = new CollisionBox(CurrentData.LocalPlayer.CollisionBox).MoveUp(CurrentData.LocalPlayer.MovementSpeed);
                if (!CollisionDetector.IsCollidingMap(newBox))
                    CurrentData.LocalPlayer.moveUp();
                moving = true;
            }
            if (state[Key.Down])
            {
                newBox = new CollisionBox(CurrentData.LocalPlayer.CollisionBox).MoveDown(CurrentData.LocalPlayer.MovementSpeed);
                if (!CollisionDetector.IsCollidingMap(newBox))
                    CurrentData.LocalPlayer.moveDown();
                moving = true;
            }
            if (state[Key.Left])
            {
                newBox = new CollisionBox(CurrentData.LocalPlayer.CollisionBox).MoveLeft(CurrentData.LocalPlayer.MovementSpeed);
                if (!CollisionDetector.IsCollidingMap(newBox))
                    CurrentData.LocalPlayer.moveLeft();
                moving = true;
            }
            if (state[Key.Right])
            {
                newBox = new CollisionBox(CurrentData.LocalPlayer.CollisionBox).MoveRight(CurrentData.LocalPlayer.MovementSpeed);
                if (!CollisionDetector.IsCollidingMap(newBox))
                   CurrentData.LocalPlayer.moveRight();
                moving = true;
            }

            if (state[Key.Space])
            {
                CurrentData.AddBomb(CurrentData.LocalPlayer.Position);
            }

            if (moving)
            {
                CurrentData.LocalPlayer.UpdateAnimation();
            }
        }
    }
}