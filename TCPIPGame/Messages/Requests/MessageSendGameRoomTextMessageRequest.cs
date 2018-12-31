using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageSendGameRoomTextMessageRequest : AClientMessage
    {
        public string TheMessage
        {
            get;
            set;
        }

        public MessageSendGameRoomTextMessageRequest(string message)
        {
            TheMessage = message;
        }

        public override void Translate(int clientID, AClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}
