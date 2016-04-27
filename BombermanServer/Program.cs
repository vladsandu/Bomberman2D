using BombermanServer.Network;
using Mina.Core.Buffer;
using Mina.Filter.Logging;
using Mina.Transport.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BombermanServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.StartServer();
        }
    }
}
