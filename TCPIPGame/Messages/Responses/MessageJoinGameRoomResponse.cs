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
    public class MessageJoinGameRoomResponse : AServerMessage
    {
        public Player ThePlayerThatJoined
        {
            get;
            private set;
        }

        public MessageJoinGameRoomResponse(Player playerThatJoined)
        {
            ThePlayerThatJoined = playerThatJoined;
        }

        public override void Translate(AServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
