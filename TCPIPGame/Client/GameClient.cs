using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;


namespace TCPIPGame
{
    public class GameClient
    {
        #region Properties
        public int ID
        {
            get;
            set;
        }

        public TcpClient TheTcpClient
        {
            get;
            set;
        }

        public NetworkStream TheNetworkStream
        {
            get;
            set;
        }
        #endregion

        public GameClient(int id, TcpClient theClient)
        {
            ID = id;
            TheTcpClient = theClient;
            TheNetworkStream = theClient.GetStream();
        }
    }
}
