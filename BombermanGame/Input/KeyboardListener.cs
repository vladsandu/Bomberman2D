using BombermanGame.Collision;
using OpenTK;
using OpenTK.Input;

namespace BombermanGame.Input
{
    public class KeyboardListener
    {
        private CurrentData CurrentData { get; set; }
        private CollisionDetector CollisionDetector { get; set; }
        public KeyboardListener(CurrentData currentData)
        {
            CurrentData = currentData;
            CollisionDetector = new CollisionDetector(CurrentData);
        }

        public void ListenKeyboardEvents()
        {
            // get the combined state of all keyboard devices:
            var state = OpenTK.Input.Keyboard.GetState();
            bool moving = false;
            if (state[Key.Up])
            {
                CurrentData.LocalPlayer.moveUp();
                moving = true;
            }
            if (state[Key.Down])
            {
                CurrentData.LocalPlayer.moveDown();
                moving = true;
            }
            if (state[Key.Left])
            {
                CurrentData.LocalPlayer.moveLeft();
                moving = true;
            }
            if (state[Key.Right])
            {
                CurrentData.LocalPlayer.moveRight();
                moving = true;
            }
            
            if (moving)
            {
                CurrentData.LocalPlayer.UpdateAnimation();
            }
        }
    }
}