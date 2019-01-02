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
    public class MessageSendGameRoomTextMessageResponse : AServerMessage
    {
        public int ClientID
        {
            get;
            private set;
        }

        public string TheMessage
        {
            get;
            private set;
        }

        public MessageSendGameRoomTextMessageResponse(int clientID, string theMessage)
        {
            ClientID = clientID;
            TheMessage = theMessage;
        }

        public override void Translate(AServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
