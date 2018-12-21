using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Client;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    public interface IServerMessage
    {
        void Translate(IServerToClientMessageTranslator translator);
    }
}
