﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Client;
using TCPIPGame.Server;
using TCPIPGame.Server.DomainObjects;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageGetGameRoomPlayersResponse : AServerMessage
    {
        public List<ANetworkPlayer> GameRoomPlayers
        {
            get;
            private set;
        }

        public MessageGetGameRoomPlayersResponse(List<ANetworkPlayer> gameRoomPlayers)
        {
            GameRoomPlayers = gameRoomPlayers;
        }

        public override void Translate(AServerToClientMessageTranslator translator)
        {
            translator.TranslateMessage(this);
        }
    }
}
