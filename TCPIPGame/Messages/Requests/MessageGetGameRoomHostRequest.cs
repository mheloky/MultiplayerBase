using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageGetGameRoomHostRequest : AClientMessage
    {
        public int RoomID
        {
            get;
            set;
        }

        public MessageGetGameRoomHostRequest(int roomID)
        {
            RoomID = roomID;
        }

        public override void Translate(int clientID, AClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}
