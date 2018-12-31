using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageJoinGameRoomRequest : AClientMessage
    {
        public int RoomID
        {
            get;
            set;
        }

        public MessageJoinGameRoomRequest(int roomID)
        {
            RoomID = roomID;
        }

        public override void Translate(int clientID, AClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}
