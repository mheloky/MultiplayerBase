﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessagePreConnectToServerRequest:IClientMessage
    {
        public string Name
        {
            get;
            set;
        }

        public MessagePreConnectToServerRequest(string name)
        {
            Name = name;
        }

        public void Translate(int clientID, IClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}