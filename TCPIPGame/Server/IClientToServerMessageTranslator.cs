using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public interface IClientToServerMessageTranslator
    {
        void TranslateMessage(int clientID, IClientMessage message);
        void TranslateMessage(int clientID, MessageConnectToServerRequest message);
    }
}
