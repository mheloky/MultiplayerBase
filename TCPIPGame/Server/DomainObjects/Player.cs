using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Server.DomainObjects
{
   [Serializable]
    public class Player:APlayer
    {
        private int _clientID;
        private string _userName;

        public Player(int clientID, string userName)
        {
            _clientID = clientID;
            _userName = userName;
        }

        public int GetClientID()
        {
            return _clientID;
        }

        public string GetUserName()
        {
            return _userName;
        }
    }
}
