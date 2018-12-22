using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Client
{
    interface IServerToClientMessageListener
    {
        event EventHandler<AServerMessage> OnReceivedServerMessage;
        void ListenAsync(TcpClient theCLient);
    }
}
