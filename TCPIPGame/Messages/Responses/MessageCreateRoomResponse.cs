using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Client;
using TCPIPGame.Server;

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

        public MessageCreateRoomResponse(string roomName)
        {
            RoomName = roomName;
        }

        public override void Translate(IServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
