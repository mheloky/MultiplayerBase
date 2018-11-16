using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;


namespace TCPIPGame
{
    public class GameClientManager
    {
        #region Properties
        int IDSeed = -1;
        Dictionary<int, GameClient> ClientIDMapping
        {
            get;
            set;
        }
        #endregion

        public GameClientManager()
        {
            ClientIDMapping = new Dictionary<int, GameClient>();
        }

        public GameClient GenerateGameClient(TcpClient gamClient)
        {
            IDSeed++;
            var theGameClient=new GameClient(IDSeed, gamClient);
            ClientIDMapping.Add(theGameClient.ID, theGameClient);
            return theGameClient;
        }

        public GameClient GetGameClientFromID(int id)
        {
            return ClientIDMapping[id];
        }
    }
}
