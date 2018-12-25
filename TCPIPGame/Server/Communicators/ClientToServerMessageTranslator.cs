using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public class ClientToServerMessageTranslator:AClientToServerMessageTranslator
    {
        public event EventHandler<MessageConnectToServerRequest> TranslatedMessageToMessageConnectToServerRequest;

        public void TranslateMessage(int clientID, MessageConnectToServerRequest message)
        {
            if(TranslatedMessageToMessageConnectToServerRequest!=null)
            {
                TranslatedMessageToMessageConnectToServerRequest(clientID, message);
            }
        }

        public void TranslateMessage(int clientID, AClientMessage message)
        {
            message.Translate(clientID, this);
        }
    }
}
