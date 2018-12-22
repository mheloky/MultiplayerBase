﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TCPIPGame.Messages;
using TCPIPGame.Server;

namespace TCPIPGame.Client
{
    public class ServerToClientMessageManager: IServerToClientMessageManager
    {
        #region Properties
        private TcpClient TheTcpClient
        {
            get;
            set;
        }
        private IServerToClientMessageTranslator TheServerToClientMessageTranslator
        {
            get;
            set;
        }

        private IServerToClientMessageListener TheServerToClientMessageListener
        {
            get;
            set;
        }
        #endregion

        public ServerToClientMessageManager(TcpClient client, IServerToClientMessageTranslator serverToClientMessageTranslator)
        {
            TheTcpClient = client;
            TheServerToClientMessageListener = new ServerToClientMessageListener() ;
            TheServerToClientMessageListener.OnReceivedServerMessage += OnReceivedServerMessage;
            TheServerToClientMessageTranslator = serverToClientMessageTranslator;
            TheServerToClientMessageListener.ListenAsync(client);
        }

        private void OnReceivedServerMessage(object sender, AServerMessage theServerMessage)
        {
            TheServerToClientMessageTranslator.TranslateMessage(theServerMessage);
            
        }

        public void SendMessageToServer(IClientMessage theClientMessage)
        {
            var nwStream = TheTcpClient.GetStream();
            var theSerializer = new Serializer();
            var bytesToRead = theSerializer.ObjectToByteArray(theClientMessage);
            nwStream.Write(bytesToRead, 0, bytesToRead.Length);
        }
    }
}
