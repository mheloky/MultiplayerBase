using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public interface AClientToServerListener
    {
        event EventHandler<AClientMessage> OnClientMessage;
        void ListenToClient(GameClient client);
    }
}
