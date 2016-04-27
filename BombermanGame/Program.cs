using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenderEngine;
using Mina.Core.Service;
using Mina.Transport.Socket;
using Mina.Core.Future;
using System.Net;
using System.Threading;
using Mina.Core.Buffer;
using Mina.Core.Session;
using BombermanGame.Network;

namespace BombermanGame
{
    class Program
    {
        public static object MemoryMonitor { get; private set; }

        static void Main(string[] args)
        {
            Game bombermanGame = new Game();
            bombermanGame.Run(60.0);
        }
    
    }
}
