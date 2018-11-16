using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace TCPIPGame
{
    public class Server
    {
        #region Properties
        public GameClientManager TheGameClientManager=new GameClientManager();
        public GameRoomManager TheGameRoomManager = new GameRoomManager();
        ClientToServerMessenger TheClientToServerMessenger = new ClientToServerMessenger();
        ClientToServerListener TheClientToServerListener = new ClientToServerListener();
        #endregion

        public void Initialize()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 80);
            TheClientToServerListener.OnClientMessage += Server_OnClientMessage;
            // we set our IP address as server's address, and we also set the port: 9999

            server.Start();  // this will start the server

            while (true)   //we wait for a connection
            {
                var gameClient = TheGameClientManager.GenerateGameClient(server.AcceptTcpClient());   //if a connection exists, the server will accept it
                var theMessage = new ServerMessage(MessageIDs.MessageID_ClientSuccesfullyConnected, gameClient.ID, "");
                TheClientToServerMessenger.SendDataToClient(gameClient, theMessage);
                TheClientToServerListener.ListenToClient(gameClient);
            }
        }

        #region Events
        private void Server_OnClientMessage(int clientID, ClientMessage clientDataMessage)
        {
            TheClientToServerMessenger.Server_OnClientMessage(clientID, clientDataMessage, TheGameRoomManager, TheGameClientManager);
        }
        #endregion
    }
}
