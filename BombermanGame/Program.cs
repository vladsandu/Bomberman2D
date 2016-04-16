using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenderEngine;

namespace BombermanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game bombermanGame = new Game();
            bombermanGame.Run(60.0);
        }
    }
}
