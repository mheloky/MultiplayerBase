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

        event EventHandler<MessagePreConnectToServerResponse> Event_OnPreConnectToServerResponseTranslated;
        event EventHandler<MessageConnectToServerResponse> Event_OnConnectToServerResponseTranslated;
        event EventHandler<MessageCreateRoomResponse> Event_OnCreateRoomServerResponseTranslated;
    }
}
