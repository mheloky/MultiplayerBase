using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Client
{
    public interface IGameClientStatus
    {
        bool IsPreConnected
        {
            get;
        }

        bool IsConnected
        {
            get;
        }

        int ClientID
        {
            get;
        }
    }
}
