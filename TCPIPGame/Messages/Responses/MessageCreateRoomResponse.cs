using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Client;
using TCPIPGame.Server;
using TCPIPGame.Server.DomainObjects;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageCreateRoomResponse : AServerMessage
    {
        public string RoomName
        {
            get;
            private set;
        }

        public int RoomID
        {
            get;
            private set;
        }

        public NetworkPlayer TheGameRoomHost
        {
            get;
            private set;
        }

        public MessageCreateRoomResponse(string roomName, int roomID, NetworkPlayer gameRoomHost)
        {
            RoomName = roomName;
            RoomID = roomID;
            TheGameRoomHost = gameRoomHost;
        }

        public override void Translate(AServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
