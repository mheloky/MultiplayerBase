using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Client
{
    public abstract class AGameClientStatus: EventArgs
    {
        public abstract bool GetIsPreConnected();
        public abstract bool GetIsConnected();
        public abstract int GetClientID();
        public abstract string GetUsername();
        abstract internal void SetClientID(int id);
        abstract internal void SetUsername(string username);
        abstract internal void SetIsPreConnected(bool isPreconnected);
        abstract internal void SetIsConnected(bool isConnected);
    }
}
