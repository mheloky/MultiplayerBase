using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Client
{
    public class ServerToClientMessageTranslator : IServerToClientMessageTranslator
    {
        public delegate void _TranslatedMessageToMessagePreConnectToServerResponse(MessagePreConnectToServerResponse message);
        public delegate void _TranslatedMessageToMessageConnectToServerResponse(MessageConnectToServerResponse message);
        public event _TranslatedMessageToMessageConnectToServerResponse TranslatedMessageToMessageConnectToServerResponse;
        public event _TranslatedMessageToMessagePreConnectToServerResponse TranslatedMessageToMessagePreConnectToServerResponse;

        public void TranslateMessage(MessagePreConnectToServerResponse message)
        {
            if(TranslatedMessageToMessagePreConnectToServerResponse != null)
            {
                TranslatedMessageToMessagePreConnectToServerResponse(message);
            }
        }

        public void TranslateMessage(MessageConnectToServerResponse message)
        {
            if (TranslatedMessageToMessageConnectToServerResponse != null)
            {
                TranslatedMessageToMessageConnectToServerResponse(message);
            }
        }

        public void TranslateMessage(IServerMessage message)
        {
            message.Translate(this);
        }
    }
}
