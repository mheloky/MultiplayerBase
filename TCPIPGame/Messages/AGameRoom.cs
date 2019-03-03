using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Messages
{
    public interface AGameRoom
    {
        #region Properties
        int ID
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        int TeamCount
        {
            get;
            set;
        }

        int TheGameRoomsHostClientID
        {
            get;
            set;
        }

        Dictionary<int, List<int>> TeamToGameClientsMapping
        {
            get;
            set;
        }

        Dictionary<int, int> ClientIDToTeamMapping
        {
            get;
            set;
        }
        #endregion

        void AddGameClientToTeam(int teamNumber, int gameClientID, bool isHost = false);

        void RemoveGameClientFromTeam(int teamNumber, int clientID);

        List<int> GetGameClientsInRoom();

        int GetGameRoomHostClientID();

        int GetGameTeamIDFromClientID(int clientID);
    }
}
