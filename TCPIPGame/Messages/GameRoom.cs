using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class GameRoom
    {
        int _roomID;
        string _roomName;

        public GameRoom(int roomID, string roomName)
        {
            _roomID = roomID;
            _roomName = roomName;
        }
        
        public int GetRoomID()
        {
            return _roomID;
        }

        public string GetRoomName()
        {
            return _roomName;
        }

    }
}
