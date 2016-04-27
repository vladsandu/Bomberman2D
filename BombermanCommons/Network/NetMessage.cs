using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanCommons.Network
{
    [Serializable]
    public class NetMessage
    {
        public MessageType MessageType { get; set; }
        public object Content { get; set; }

        public NetMessage(MessageType messageType, Object content)
        {
            MessageType = messageType;
            Content = content;
        }
    }
}
