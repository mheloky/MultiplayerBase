using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessagePreConnectToServerRequest:AClientMessage
    {
        public string Name
        {
            get;
            set;
        }

        public MessagePreConnectToServerRequest(string name)
        {
            Name = name;
        }

        public override void Translate(int clientID, AClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}
