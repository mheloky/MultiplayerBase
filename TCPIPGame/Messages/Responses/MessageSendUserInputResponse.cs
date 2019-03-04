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
    public class MessageSendUserInputResponse : AServerMessage
    {
        public int ClientID
        {
            get;
            set;
        }

        public NetworkUserInput TheUserInput
        {
            get;
            set;
        }

        public MessageSendUserInputResponse(int clientID, NetworkUserInput userInput)
        {
            ClientID = clientID;
            TheUserInput = userInput;
        }

        public override void Translate(AServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
