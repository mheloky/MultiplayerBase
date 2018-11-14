using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPIPGame;

namespace TCPIPGame
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

        public void CreateRoom(int teamCount)
        {
            IDSeed++;
            GameRooms.Add(GenerateManageeID(), new GameRoom(teamCount));
        }

        public void AddPlayerToGameRoom(GameClient theClient, int roomID, int teamID)
        {
            GameRooms[roomID].AddGameClientToTeam(teamID, theClient);
            GameClientToGameRoomMap.Add(theClient.ID, roomID);
        }

        public GameClient[] GetGameClientsInRoom(int roomID)
        {
            return GameRooms[roomID].GetGameClientsInRoom();
        }

        public int GetClientRoomID(int clientID)
        {
            return GameClientToGameRoomMap[clientID];
        }

        public int GenerateManageeID()
        {
            IDSeed++;
            return IDSeed;
        }
    }
}
