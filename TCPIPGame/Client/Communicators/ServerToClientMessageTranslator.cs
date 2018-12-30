﻿using System;
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

        public void TranslateMessage(AServerMessage message)
        {
            message.Translate(this);
        }
    }
}
