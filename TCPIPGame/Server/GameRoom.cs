﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        Dictionary<int, List<int>> TeamToGameClientsMapping
        {
            get;
            set;
        }

        public GameRoom(int teamCount)
        {
            TeamCount = teamCount;
            TeamToGameClientsMapping = new Dictionary<int, List<int>>();

            for (int i = 0; i < TeamCount; i++)
            {
                TeamToGameClientsMapping.Add(i, new List<int>());
            }
        }

        public void AddGameClientToTeam(int teamNumber, int gameClientID)
        {
            TeamToGameClientsMapping[teamNumber].Add(gameClientID);
        }

        public void RemoveGameClientFromTeam(int teamNumber,int clientID)
        {
            TeamToGameClientsMapping[teamNumber].Remove(clientID);
        }

        public int[] GetGameClientsInRoom()
        {
            List<int> gameClients = new List<int>();
            for(int i=0;i< TeamToGameClientsMapping.Count;i++)
            {
                gameClients.AddRange(TeamToGameClientsMapping[i]);
            }

            return gameClients.ToArray();
        }

    }
}