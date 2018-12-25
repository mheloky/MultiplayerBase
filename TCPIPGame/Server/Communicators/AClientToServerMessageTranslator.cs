using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public interface AClientToServerMessageTranslator
    {
        void TranslateMessage(int clientID, AClientMessage message);
        void TranslateMessage(int clientID, MessageConnectToServerRequest message);
        event EventHandler<MessageConnectToServerRequest> TranslatedMessageToMessageConnectToServerRequest;
    }
}
