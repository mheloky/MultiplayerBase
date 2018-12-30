using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageGetGameRoomPlayersRequest : AClientMessage
    {
        public int RoomID
        {
            get;
            set;
        }

        public MessageGetGameRoomPlayersRequest(int roomID)
        {
            RoomID = roomID;
        }

        public override void Translate(int clientID, AClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}
