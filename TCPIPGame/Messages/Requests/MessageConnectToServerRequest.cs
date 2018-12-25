using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageConnectToServerRequest:AClientMessage
    {
        public string Name
        {
            get;
            set;
        }

        public MessageConnectToServerRequest(string name)
        {
            Name = name;
        }

        public void Translate(int clientID, AClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}
