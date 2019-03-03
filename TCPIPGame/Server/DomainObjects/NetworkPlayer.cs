using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Server.DomainObjects
{
   [Serializable]
    public class NetworkPlayer:ANetworkPlayer
    {
        #region Properties
        private int _clientID;
        private string _userName;
        private int _teamID;
        #endregion

        public NetworkPlayer(int clientID, string userName, int teamID)
        {
            _clientID = clientID;
            _userName = userName;
            _teamID = teamID;
        }

        #region Helper Methods
        public int GetClientID()
        {
            return _clientID;
        }

        public string GetUserName()
        {
            return _userName;
        }

        public int GetTeamID()
        {
            return _teamID;
        }
        #endregion
    }
}
