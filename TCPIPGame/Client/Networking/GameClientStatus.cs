using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Client
{
    public class GameClientStatus : AGameClientStatus
    {
        private int _clientID;
        private string _username;
        private bool _isConnected;
        private bool _isPreConnected;

        public override int GetClientID()
        {
            return _clientID;
        }

        public override bool GetIsConnected()
        {
            return _isConnected;
        }

        public override bool GetIsPreConnected()
        {
            return _isPreConnected;
        }

        internal override void SetClientID(int id)
        {
            _clientID = id;
        }

        internal override void SetIsPreConnected(bool isPreconnected)
        {
            _isPreConnected = isPreconnected;
        }

        internal override void SetIsConnected(bool isConnected)
        {
            _isConnected = isConnected;
        }

        public override string GetUsername()
        {
            return _username;
        }

        internal override void SetUsername(string username)
        {
            _username = username;
        }
    }
}
