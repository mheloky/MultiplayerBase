using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Client
{
    public interface IServerToClientMessageTranslator
    {
        void TranslateMessage(IServerMessage message);
        void TranslateMessage(MessagePreConnectToServerResponse message);
        void TranslateMessage(MessageConnectToServerResponse message);
    }
}
