using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public abstract class AClientMessage:EventArgs
    {
        public abstract void Translate(int clientID, AClientToServerMessageTranslator translator);
    }
}
