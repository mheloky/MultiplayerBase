using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    public interface AClientMessage
    {
        void Translate(int clientID, AClientToServerMessageTranslator translator);
    }
}
