using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Client
{
    public interface IServerToClientMessageManager
    {
        void SendMessageToServer(IClientMessage theClientMessage);
    }
}
