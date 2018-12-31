using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Client
{
    public class ServerToClientMessageTranslator : AServerToClientMessageTranslator
    {
        #region Events
        public event EventHandler<MessagePreConnectToServerResponse> Event_OnPreConnectToServerResponseTranslated;
        public event EventHandler<MessageConnectToServerResponse> Event_OnConnectToServerResponseTranslated;
        public event EventHandler<MessageCreateRoomResponse> Event_OnCreateRoomServerResponseTranslated;
        public event EventHandler<MessageGetGameRoomHostResponse> Event_OnGetGameRoomHostResponseTranslated;
        public event EventHandler<MessageGetGameRoomPlayersResponse> Event_OnGetGameRoomPlayersResponseTranslated;
        public event EventHandler<MessageJoinGameRoomResponse> Event_OnJoinGameRoomResponseTranslated;
        public event EventHandler<MessageSendGameRoomTextMessageResponse> Event_OnSendGameRoomTextMessageResponseTranslated;
        public event EventHandler<MessageGetGameRoomsResponse> Event_OnGetGameRoomsResponseTranslated;
        #endregion

        public void TranslateMessage(MessagePreConnectToServerResponse message)
        {
            if(Event_OnPreConnectToServerResponseTranslated != null)
            {
                Event_OnPreConnectToServerResponseTranslated(null,message);
            }
        }

        public void TranslateMessage(MessageConnectToServerResponse message)
        {
            if (Event_OnConnectToServerResponseTranslated != null)
            {
                Event_OnConnectToServerResponseTranslated(null,message);
            }
        }

        public void TranslateMessage(MessageCreateRoomResponse message)
        {
            if (Event_OnCreateRoomServerResponseTranslated != null)
            {
                Event_OnCreateRoomServerResponseTranslated(null, message);
            }
        }

        public void TranslateMessage(MessageGetGameRoomHostResponse message)
        {
            if (Event_OnGetGameRoomHostResponseTranslated != null)
            {
                Event_OnGetGameRoomHostResponseTranslated(null, message);
            }
        }

        public void TranslateMessage(MessageGetGameRoomPlayersResponse message)
        {
            if (Event_OnGetGameRoomPlayersResponseTranslated != null)
            {
                Event_OnGetGameRoomPlayersResponseTranslated(null, message);
            }
        }

        public void TranslateMessage(MessageJoinGameRoomResponse message)
        {
            if (Event_OnJoinGameRoomResponseTranslated != null)
            {
                Event_OnJoinGameRoomResponseTranslated(null, message);
            }
        }

        public void TranslateMessage(MessageSendGameRoomTextMessageResponse message)
        {
            if (Event_OnSendGameRoomTextMessageResponseTranslated != null)
            {
                Event_OnSendGameRoomTextMessageResponseTranslated(null, message);
            }
        }

        public void TranslateMessage(MessageGetGameRoomsResponse message)
        {
            if (Event_OnGetGameRoomsResponseTranslated != null)
            {
                Event_OnGetGameRoomsResponseTranslated(null, message);
            }
        }

        public void TranslateMessage(AServerMessage message)
        {
            message.Translate(this);
        }
    }
}
