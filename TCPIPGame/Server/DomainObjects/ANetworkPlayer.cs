using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Server.DomainObjects
{
    public interface ANetworkPlayer
    {
        int GetClientID();
        int GetTeamID();
        string GetUserName();
    }
}
