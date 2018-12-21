using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    public interface IClientMessage
    {
        void Translate(int clientID, IClientToServerMessageTranslator translator);
    }
}
