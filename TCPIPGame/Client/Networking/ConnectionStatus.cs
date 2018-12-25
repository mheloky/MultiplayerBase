using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Client.Networking
{
    public class ConnectionStatus: EventArgs
    {
        bool Completed
        {
            get;
            set;
        }
    }
}
