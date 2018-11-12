using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPIPGame
{
    public class GameRoom
    {
        public int ID
        {
            get;
            set;
        }

        int TeamCount
        {
            get;
            set;
        }

        Dictionary<int, Dictionary<int,GameClient>> TeamToGameClientsMapping
        {
            get;
            set;
        }

        public GameRoom(int teamCount)
        {
            TeamCount = teamCount;
            TeamToGameClientsMapping = new Dictionary<int, Dictionary<int, GameClient>>();

            for (int i = 0; i < TeamCount; i++)
            {
                TeamToGameClientsMapping.Add(i, new Dictionary<int, GameClient>());
            }
        }

        public void AddGameClientToTeam(int teamNumber, GameClient gameClient)
        {
            TeamToGameClientsMapping[teamNumber].Add(gameClient.ID,gameClient);
        }

        public void RemoveGameClientFromTeam(int teamNumber,int clientID)
        {
            TeamToGameClientsMapping[teamNumber].Remove(clientID);
        }

        public GameClient[] GetGameClientsInRoom()
        {
            List<GameClient> gameClients = new List<GameClient>();
            for(int i=0;i< TeamToGameClientsMapping.Count;i++)
            {
                gameClients.AddRange(TeamToGameClientsMapping[i].Select(x=>x.Value));
            }

            return gameClients.ToArray();
        }

    }
}
