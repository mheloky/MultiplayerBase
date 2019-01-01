using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TCPIPGame;
using TCPIPGame.Server.DomainObjects;

namespace TCPIPGame.Server
{
    public class GameRoomManager:IManager
    {
        int IDSeed = -1;
        Dictionary<int,GameRoom> GameRooms
        {
            get;
            set;
        }
        Dictionary<int, int> GameClientToGameRoomMap
        {
            get;
            set;
        }

        public GameRoomManager()
        {
            GameRooms = new Dictionary<int, GameRoom>();
            GameClientToGameRoomMap = new Dictionary<int, int>();
        }

        public int CreateRoom(int teamCount, string gameRoomName, int theGameRoomsHostClientID)
        {
            GameRooms.Add(GenerateManageeID(), new GameRoom(teamCount, gameRoomName));
            return IDSeed;
        }

        public void AddPlayerToGameRoom(int clientID, int roomID, int teamID, bool isHost=false)
        {
            GameRooms[roomID].AddGameClientToTeam(teamID, clientID, isHost);
            GameClientToGameRoomMap.Add(clientID, roomID);
        }

        public List<int> GetGameClientsInRoom(int roomID)
        {
            return GameRooms[roomID].GetGameClientsInRoom();
        }

        public int GetClientRoomID(int clientID)
        {
            return GameClientToGameRoomMap[clientID];
        }

        public int GetGameRoomHostClientIDFromGameRoomID(int gameRoomID)
        {
            return GameRooms[gameRoomID].GetGameRoomHostClientID();
        }

        public List<GameRoom> GetGameRooms()
        {
            return GameRooms.Select(x => x.Value).ToArray().ToList();
        }

        public int GenerateManageeID()
        {
            IDSeed++;
            return IDSeed;
        }
    }
}
