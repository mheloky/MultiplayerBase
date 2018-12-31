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
        public string TheMessage
        {
            get;
            private set;
        }

        public MessageSendGameRoomTextMessageResponse(string theMessage)
        {
            TheMessage = theMessage;
        }

        public override void Translate(AServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
