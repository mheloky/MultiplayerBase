using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public class ClientToServerMeossageTranslator:AClientToServerMessageTranslator
    {
        public delegate void _TranslatedMessageToMessageConnectToServerRequest(int clientID, MessageConnectToServerRequest message);
        public event _TranslatedMessageToMessageConnectToServerRequest TranslatedMessageToMessageConnectToServerRequest;

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
