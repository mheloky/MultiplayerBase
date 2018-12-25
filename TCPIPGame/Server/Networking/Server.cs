﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public class Server
    {
        #region Properties
        public GameClientManager TheGameClientManager=new GameClientManager();
        public GameRoomManager TheGameRoomManager = new GameRoomManager();
        AClientToServerMessenger TheClientToServerMessenger = new ClientToServerMessenger();
        AClientToServerListener TheClientToServerListener = new ClientToServerListener();
        AClientToServerMessageTranslator TheClientToServerMeossageTranslator = new ClientToServerMessageTranslator();
        #endregion

        public void Initialize()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 80);
            TheClientToServerListener.OnClientMessage += Server_OnClientMessage_Translate;
            TheClientToServerMeossageTranslator.TranslatedMessageToMessageConnectToServerRequest += TheClientToServerMeossageTranslator_TranslatedMessageToMessageConnectToServerRequest;
            // we set our IP address as server's address, and we also set the port: 9999

            server.Start();  // this will start the server

            while (true)   //we wait for a connection
            {
                var gameClient = TheGameClientManager.GenerateGameClient(server.AcceptTcpClient());   //if a connection exists, the server will accept it
                var theMessage = new MessagePreConnectToServerResponse(true);
                TheClientToServerMessenger.SendDataToClient(gameClient, theMessage);
                TheClientToServerListener.ListenToClient(gameClient);
            }
        }

        private void TheClientToServerMeossageTranslator_TranslatedMessageToMessageConnectToServerRequest(object clientID, MessageConnectToServerRequest message)
        {
            TheClientToServerMessenger.OnClientMessage_MessageConnectToServerRequest((int)clientID, message, TheGameRoomManager, TheGameClientManager);
        }

        #region Events
        private void Server_OnClientMessage_Translate(object clientID, AClientMessage clientDataMessage)
        {
            TheClientToServerMeossageTranslator.TranslateMessage((int)clientID, clientDataMessage);
        
        }
        #endregion
    }
}