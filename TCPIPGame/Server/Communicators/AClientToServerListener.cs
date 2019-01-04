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
        event Action<int, byte[]> OnLowLevelClientMessage;
        void ListenToClient(GameClient client);
    }
}
