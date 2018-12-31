using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public interface AClientToServerMessageTranslator
    {
        void TranslateMessage(int clientID, AClientMessage message);
        void TranslateMessage(int clientID, MessageConnectToServerRequest message);
        void TranslateMessage(int clientID, MessageCreateRoomRequest message);
        void TranslateMessage(int clientID, MessageGetGameRoomHostRequest message);
        void TranslateMessage(int clientID, MessageGetGameRoomPlayersRequest message);
        void TranslateMessage(int clientID, MessageJoinGameRoomRequest message);
        void TranslateMessage(int clientID, MessageSendGameRoomTextMessageRequest message);
        void TranslateMessage(int clientID, MessageGetGameRoomsRequest message);

        event EventHandler<MessageConnectToServerRequest> TranslatedMessageToMessageConnectToServerRequest;
        event EventHandler<MessageCreateRoomRequest> TranslatedMessageToMessageCreateRoomRequest;
        event EventHandler<MessageGetGameRoomHostRequest> TranslatedMessageGetGameRoomHostRequest;
        event EventHandler<MessageGetGameRoomPlayersRequest> TranslatedMessageGetGamePlayersRequest;
        event EventHandler<MessageJoinGameRoomRequest> TranslatedMessageJoinGameRoomRequest;
        event EventHandler<MessageSendGameRoomTextMessageRequest> TranslatedMessageSendGameRoomTextMessageRequest;
        event EventHandler<MessageGetGameRoomsRequest> TranslatedGetGameRoomsRequest;
    }
}
