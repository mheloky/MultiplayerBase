using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Client;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    public abstract class AServerMessage:EventArgs
    {
        public abstract void Translate(IServerToClientMessageTranslator translator);
    }
}
