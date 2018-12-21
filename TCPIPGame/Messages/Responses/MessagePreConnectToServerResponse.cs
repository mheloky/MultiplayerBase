using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Client;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessagePreConnectToServerResponse:IServerMessage
    {
        public bool Connected
        {
            get;
            private set;
        }

        public MessagePreConnectToServerResponse(bool connected)
        {
            Connected = connected;
        }

        public void Translate(IServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
