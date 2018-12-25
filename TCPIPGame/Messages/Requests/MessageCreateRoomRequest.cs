using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageCreateRoomRequest : AClientMessage
    {
        public string RoomName
        {
            get;
            set;
        }

        public MessageCreateRoomRequest(string roomName)
        {
            RoomName = roomName;
        }

        public override void Translate(int clientID, AClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}
