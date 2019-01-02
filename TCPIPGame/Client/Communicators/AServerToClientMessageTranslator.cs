using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Client
{
    public interface AServerToClientMessageTranslator
    {
        void TranslateMessage(AServerMessage message);
        void TranslateMessage(MessagePreConnectToServerResponse message);
        void TranslateMessage(MessageConnectToServerResponse message);
        void TranslateMessage(MessageCreateRoomResponse message);
        void TranslateMessage(MessageGetGameRoomHostResponse message);
        void TranslateMessage(MessageGetGameRoomPlayersResponse message);
        void TranslateMessage(MessageJoinGameRoomResponse message);
        void TranslateMessage(MessageSendGameRoomTextMessageResponse message);
        void TranslateMessage(MessageGetGameRoomsResponse message);
        void TranslateMessage(MessageSendUserInputResponse message);

        event EventHandler<MessagePreConnectToServerResponse> Event_OnPreConnectToServerResponseTranslated;
        event EventHandler<MessageConnectToServerResponse> Event_OnConnectToServerResponseTranslated;
        event EventHandler<MessageCreateRoomResponse> Event_OnCreateRoomServerResponseTranslated;
        event EventHandler<MessageGetGameRoomHostResponse> Event_OnGetGameRoomHostResponseTranslated;
        event EventHandler<MessageGetGameRoomPlayersResponse> Event_OnGetGameRoomPlayersResponseTranslated;
        event EventHandler<MessageJoinGameRoomResponse> Event_OnJoinGameRoomResponseTranslated;
        event EventHandler<MessageSendGameRoomTextMessageResponse> Event_OnSendGameRoomTextMessageResponseTranslated;
        event EventHandler<MessageGetGameRoomsResponse> Event_OnGetGameRoomsResponseTranslated;
        event EventHandler<MessageSendUserInputResponse> Event_OnSendUserInputResponseTranslated;
    }
}
