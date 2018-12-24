using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Client
{
    public class GameClientStatus : AGameClientStatus
    {
        private int _clientID;
        private bool _isConnected;
        private bool _isPreConnected;

        public int GetClientID()
        {
            return _clientID;
        }

        public bool GetIsConnected()
        {
            return _isConnected;
        }

        public bool GetIsPreConnected()
        {
            return _isPreConnected;
        }

        internal void SetClientID(int id)
        {
            _clientID = id;
        }

        internal void SetIsPreConnected(bool isPreconnected)
        {
            _isPreConnected = isPreconnected;
        }

        internal void SetIsConnected(bool isConnected)
        {
            _isConnected = isConnected;
        }
    }
}
