using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Client;
using TCPIPGame.Server;
using TCPIPGame.Server.DomainObjects;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageGetGameRoomHostResponse : AServerMessage
    {
        public NetworkPlayer TheGameRoomHost
        {
            get;
            private set;
        }

        public MessageGetGameRoomHostResponse(NetworkPlayer gameRoomHost)
        {
             TheGameRoomHost = gameRoomHost;
        }

        public override void Translate(AServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
