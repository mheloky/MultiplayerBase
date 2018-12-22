using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageCreateRoomRequest : IClientMessage
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

        public void Translate(int clientID, IClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}
