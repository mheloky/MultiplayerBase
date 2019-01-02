using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server.DomainObjects;

namespace TCPIPGame.Server.GameStructure
{
    public class PlayerManager
    {
        public Player GeneratePlayerFromClientID(int clientID,  int roomID, GameClientManager gameClientManager, GameRoomManager gameRoomManager)
        {
            var teamID = gameRoomManager.GetTeamFromClientIDAndRoomID(roomID, clientID);
            return new Player(gameClientManager.GetGameClientFromClientID(clientID).ID, gameClientManager.GetGameClientFromClientID(clientID).Name, teamID);
        }
    }
}
