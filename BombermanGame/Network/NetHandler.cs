using BombermanCommons;
using BombermanCommons.Network;
using Mina.Core.Buffer;
using Mina.Core.Future;
using Mina.Core.Service;
using Mina.Core.Session;
using Mina.Transport.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BombermanGame.Network
{
    public class NetHandler
    {
        private Connector Connector { get; set; }  
        private CurrentData CurrentData { get; set; }
        private IoSession Session { get; set; }
        public NetHandler(CurrentData currentData)
        {
            CurrentData = currentData;
            Connector = new Connector(currentData);
        }

        public void Connect()
        {
            IConnectFuture connFuture = Connector.Connect(new IPEndPoint(IPAddress.Loopback, 18567));
            Session = connFuture.Session;
            connFuture.Await();
            SendStartSessionMessage();
        }

        private void SendStartSessionMessage()
        {
            SendMessage(new NetMessage(MessageType.START_SESSION, null));
        }

        public void SendMessage(object obj)
        {
            IoBuffer buffer = IoBuffer.Allocate(8);
            buffer.AutoExpand = true;
            buffer.PutObject(obj);
            buffer.Flip();
            Session.Write(buffer);
        }
    }
}
