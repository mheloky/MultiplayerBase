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

        public void TranslateMessage(AServerMessage message)
        {
            message.Translate(this);
        }
    }
}
