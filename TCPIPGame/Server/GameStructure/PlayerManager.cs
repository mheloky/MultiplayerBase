using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server.DomainObjects;

namespace TCPIPGame.Server.GameStructure
{
    public class PlayerManager
    {
        public Player GetPlayerFromClientID(int clientID, GameClientManager gameClientManager)
        {
            return new Player(gameClientManager.GetGameClientFromClientID(clientID).ID, gameClientManager.GetGameClientFromClientID(clientID).Name);
        }

        public List<APlayer> GetPlayersFromClientIDs(List<int> clientIDs, GameClientManager gameClientManager)
        {
            var players = new List<APlayer>();
            for(int i=0;i<clientIDs.Count;i++)
            {
                var theClientID = clientIDs[i];
                players.Add(GetPlayerFromClientID(theClientID, gameClientManager));
            }

            return players;
        }
    }
}
