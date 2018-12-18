using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TCPIPGame
{
    public class MessageIDs
    {
        public static int ClienFailedToConnect = 1;
        public static int MessageID_ClientSuccesfullyConnected = 2;
        public static int MessageID_CreateGameRoom = 3;
        public static int MessageID_JoinGameRoom = 4;
        public static int MessageID_MoveAxisX = 5;
        public static int MessageID_Mesage = 6;

        public static int MessageID_GetServerGameRooms = 7;
    }
}
