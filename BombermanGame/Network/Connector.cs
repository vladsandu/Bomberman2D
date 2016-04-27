using BombermanCommons;
using Mina.Transport.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanGame.Network
{
    class Connector : AsyncDatagramConnector
    {
        private CurrentData CurrentData { get; set; }
        public Connector(CurrentData currentData)
        {
            CurrentData = currentData;

            ExceptionCaught += (s, e) =>
            {
                Console.WriteLine(e.Exception);
            };
            MessageReceived += (s, e) =>
            {
                Console.WriteLine("Session recv...");
            };
            MessageSent += (s, e) =>
            {
                Console.WriteLine("Session sent...");
            };
            SessionCreated += (s, e) =>
            {
                Console.WriteLine("Session created...");
            };
            SessionOpened += (s, e) =>
            {
                Console.WriteLine("Session opened...");
            };
            SessionClosed += (s, e) =>
            {
                Console.WriteLine("Session closed...");
            };
            SessionIdle += (s, e) =>
            {
                Console.WriteLine("Session idle...");
            };
        }
    }
}
