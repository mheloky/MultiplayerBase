using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Client;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageConnectToServerResponse: AServerMessage
    {
        public int ClientID
        {
            get;
            private set;
        }

        public MessageConnectToServerResponse(int clientID)
        {
            ClientID = clientID;
        }

        public override void Translate(AServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
