using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BombermanCommons
{
    public class Settings
    {
        public static int WIDTH = DisplayDevice.Default.Width;
        public static int HEIGHT = DisplayDevice.Default.Height;
        
        public static float GetAspectRatio()
        {
            return WIDTH / HEIGHT;
        }
    }
}
