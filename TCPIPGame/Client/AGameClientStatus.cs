using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Client
{
    public interface AGameClientStatus
    {
        bool GetIsPreConnected();
        bool GetIsConnected();
        int GetClientID();
    }
}
