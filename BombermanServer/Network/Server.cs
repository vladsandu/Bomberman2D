using Mina.Core.Buffer;
using Mina.Filter.Logging;
using Mina.Transport.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BombermanServer.Network
{
    class Server
    {
        Acceptor Acceptor { get; set; }
        bool ShouldStop { get; set; }
        public Server()
        {
            Acceptor = new Acceptor();
            ShouldStop = false;
        }

        public void StartServer()
        {
            Console.WriteLine("UDPServer listening on port " + 18567);
            Acceptor.Open(18567);
            while (!ShouldStop)
            {
                Thread.Sleep(1);
            }
        }
    }
}
