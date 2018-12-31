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
    public class MessageGetGameRoomsResponse : AServerMessage
    {
        public List<GameRoom> TheGameRooms
        {
            get;
            private set;
        }

        public MessageGetGameRoomsResponse(List<GameRoom> theGameRooms)
        {
            TheGameRooms = theGameRooms;
        }

        public override void Translate(AServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
