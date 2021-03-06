﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Server
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

        public GameClient GetGameClientFromClientID(int clientID)
        {
            return ClientIDMapping[clientID];
        }

        public List<GameClient> GetGameClientsFromClientIDs(List<int> clientIDs)
        {
            var gameClients = new List<GameClient>(); 
            for(int i=0;i<clientIDs.Count;i++)
            {
                var clientID = clientIDs[i];
                gameClients.Add(GetGameClientFromClientID(clientID));
            }
            return gameClients;
        }
    }
}
