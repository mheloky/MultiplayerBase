using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Client
{
    public class GameClientStatus : IGameClientStatus
    {
        public bool IsPreConnected
        {
            get;
            internal set;
        }

        public bool IsConnected
        {
            get;
            internal set;
        }

        public int ClientID
        {
            get;
            internal set;
        }
    }
}
