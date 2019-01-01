using System;
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
        AClientToServerMessageManager TheClientToServerMessenger = new ClientToServerMessageManager ();
        AClientToServerListener TheClientToServerListener = new ClientToServerListener();
        AClientToServerMessageTranslator TheClientToServerMeossageTranslator = new ClientToServerMessageTranslator();
        #endregion

        public void Initialize()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 80);
            TheClientToServerListener.OnClientMessage += Server_OnClientMessage_Translate;
            TheClientToServerMeossageTranslator.TranslatedMessageToMessageConnectToServerRequest += TheClientToServerMeossageTranslator_TranslatedMessageToMessageConnectToServerRequest;
            TheClientToServerMeossageTranslator.TranslatedMessageToMessageCreateRoomRequest += TheClientToServerMeossageTranslator_TranslatedMessageToMessageCreateRoomRequest;
            TheClientToServerMeossageTranslator.TranslatedMessageGetGameRoomHostRequest += TheClientToServerMeossageTranslator_TranslatedMessageGetGameRoomHostRequest;
            TheClientToServerMeossageTranslator.TranslatedMessageGetGamePlayersRequest += TheClientToServerMeossageTranslator_TranslatedMessageGetGamePlayersRequest;
            TheClientToServerMeossageTranslator.TranslatedMessageGetGameRoomsRequest += TheClientToServerMeossageTranslator_TranslatedMessageGetGameRoomsRequest;
            TheClientToServerMeossageTranslator.TranslatedMessageJoinGameRoomRequest += TheClientToServerMeossageTranslator_TranslatedMessageJoinGameRoomRequest; ;
            TheClientToServerMeossageTranslator.TranslatedMessageSendGameRoomTextMessageRequest += TheClientToServerMeossageTranslator_TranslatedMessageSendGameRoomTextMessageRequest;
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

        private void TheClientToServerMeossageTranslator_TranslatedMessageToMessageCreateRoomRequest(object clientID, MessageCreateRoomRequest e)
        {
            TheClientToServerMessenger.OnClientMessage_MessageCreateRoomRequest((int)clientID, e, TheGameRoomManager, TheGameClientManager);
        }

        private void TheClientToServerMeossageTranslator_TranslatedMessageToMessageConnectToServerRequest(object clientID, MessageConnectToServerRequest message)
        {
            TheClientToServerMessenger.OnClientMessage_MessageConnectToServerRequest((int)clientID, message, TheGameRoomManager, TheGameClientManager);
        }

        private void TheClientToServerMeossageTranslator_TranslatedMessageGetGameRoomHostRequest(object clientID, MessageGetGameRoomHostRequest e)
        {
           TheClientToServerMessenger.OnClientMessage_MessageGetGameRoomHostRequest((int)clientID, e, TheGameRoomManager, TheGameClientManager);
        }


        private void TheClientToServerMeossageTranslator_TranslatedMessageGetGameRoomsRequest(object clientID, MessageGetGameRoomsRequest e)
        {
            TheClientToServerMessenger.OnClientMessage_MessageGetGameRoomsRequest((int)clientID, e, TheGameRoomManager, TheGameClientManager);
        }

        private void TheClientToServerMeossageTranslator_TranslatedMessageGetGamePlayersRequest(object clientID, MessageGetGameRoomPlayersRequest e)
        {
            TheClientToServerMessenger.OnClientMessage_MessageGetGameRoomPlayersRequest((int)clientID, e, TheGameRoomManager, TheGameClientManager);
        }

        private void TheClientToServerMeossageTranslator_TranslatedMessageSendGameRoomTextMessageRequest(object clientID, MessageSendGameRoomTextMessageRequest e)
        {
            TheClientToServerMessenger.OnClientMessage_MessageSendGameRoomTextMessageRequest((int)clientID, e, TheGameRoomManager, TheGameClientManager);
        }

        private void TheClientToServerMeossageTranslator_TranslatedMessageJoinGameRoomRequest(object clientID, MessageJoinGameRoomRequest e)
        {
            TheClientToServerMessenger.OnClientMessage_MessageJoinGameRoomRequest((int)clientID, e, TheGameRoomManager, TheGameClientManager);
        }

        #region Events
        private void Server_OnClientMessage_Translate(object clientID, AClientMessage clientDataMessage)
        {
            TheClientToServerMeossageTranslator.TranslateMessage((int)clientID, clientDataMessage);
        
        }
        #endregion
    }
}
