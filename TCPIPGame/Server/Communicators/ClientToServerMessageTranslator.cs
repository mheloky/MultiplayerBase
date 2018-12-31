﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public class ClientToServerMessageTranslator:AClientToServerMessageTranslator
    {
        public event EventHandler<MessageConnectToServerRequest> TranslatedMessageToMessageConnectToServerRequest;
        public event EventHandler<MessageCreateRoomRequest> TranslatedMessageToMessageCreateRoomRequest;
        public event EventHandler<MessageGetGameRoomHostRequest> TranslatedMessageGetGameRoomHostRequest;
        public event EventHandler<MessageGetGameRoomPlayersRequest> TranslatedMessageGetGamePlayersRequest;
        public event EventHandler<MessageJoinGameRoomRequest> TranslatedMessageJoinGameRoomRequest;
        public event EventHandler<MessageSendGameRoomTextMessageRequest> TranslatedMessageSendGameRoomTextMessageRequest;
        public event EventHandler<MessageGetGameRoomsRequest> TranslatedGetGameRoomsRequest;

        public void TranslateMessage(int clientID, MessageConnectToServerRequest message)
        {
            if(TranslatedMessageToMessageConnectToServerRequest!=null)
            {
                TranslatedMessageToMessageConnectToServerRequest(clientID, message);
            }
        }

        public void TranslateMessage(int clientID, MessageCreateRoomRequest message)
        {
            if (TranslatedMessageToMessageCreateRoomRequest != null)
            {
                TranslatedMessageToMessageCreateRoomRequest(clientID, message);
            }
        }

        public void TranslateMessage(int clientID, MessageGetGameRoomHostRequest message)
        {
            if (TranslatedMessageGetGameRoomHostRequest != null)
            {
                TranslatedMessageGetGameRoomHostRequest(clientID, message);
            }
        }

        public void TranslateMessage(int clientID, MessageGetGameRoomPlayersRequest message)
        {
            if (TranslatedMessageGetGamePlayersRequest != null)
            {
                TranslatedMessageGetGamePlayersRequest(clientID, message);
            }
        }

        public void TranslateMessage(int clientID, MessageJoinGameRoomRequest message)
        {
            if (TranslatedMessageJoinGameRoomRequest != null)
            {
                TranslatedMessageJoinGameRoomRequest(clientID, message);
            }
        }

        public void TranslateMessage(int clientID, MessageSendGameRoomTextMessageRequest message)
        {
            if (TranslatedMessageSendGameRoomTextMessageRequest != null)
            {
                TranslatedMessageSendGameRoomTextMessageRequest(clientID, message);
            }
        }

        public void TranslateMessage(int clientID, MessageGetGameRoomsRequest message)
        {
            if (TranslatedGetGameRoomsRequest != null)
            {
                TranslatedGetGameRoomsRequest(clientID, message);
            }
        }

        public void TranslateMessage(int clientID, AClientMessage message)
        {
            message.Translate(clientID, this);
        }
    }
}
