using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPIPGame;

namespace TCPIPGame
{
    public class GameRoomManager
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

        public void CreateRoom()
        {
            IDSeed++;
            GameRooms.Add(GenerateRoomID(), new GameRoom(2));
        }

        public void AddPlayerToGameRoom(GameClient theClient, int roomID)
        {
            GameRooms[roomID].AddGameClientToTeam(1, theClient);
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

        private int GenerateRoomID()
        {
            IDSeed++;
            return IDSeed;
        }



    }
}
