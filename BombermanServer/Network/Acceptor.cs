using Mina.Core.Buffer;
using Mina.Filter.Logging;
using Mina.Transport.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BombermanServer.Network
{
    public class Acceptor : AsyncDatagramAcceptor
    {
        public Acceptor()
        {
            FilterChain.AddLast("logger", new LoggingFilter());
            SessionConfig.ReuseAddress = true;
            SessionCreated += (s, e) =>
            {
                Console.WriteLine("Session created..." + e.Session);
            };
            MessageReceived += (s, e) =>
            {
                IoBuffer buf = e.Message as IoBuffer;

                if (buf != null)
                {
                    Console.WriteLine("New value for {0}: {1}", e.Session, buf.GetObject());
                }
            };
            SessionClosed += (s, e) =>
            {
                Console.WriteLine("Session closed...");
            };
        }

        public void Open(int port)
        {
            Bind(new IPEndPoint(IPAddress.Any, port));
        }
    }
}
