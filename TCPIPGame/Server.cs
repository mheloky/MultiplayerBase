using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPIPGame
{
    public class Server
    {
        public delegate void DelegateOnClientMessage(int clientID, Message data);
        public event DelegateOnClientMessage OnClientMessage;
        public GameClientManager TheGameClientManager=new GameClientManager();
        public GameRoomManager TheGameRoomManager = new GameRoomManager();
        public void Initialize()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 80);
            this.OnClientMessage += Server_OnClientMessage;
            // we set our IP address as server's address, and we also set the port: 9999

            server.Start();  // this will start the server

            while (true)   //we wait for a connection
            {
                GameClient gameClient = TheGameClientManager.GenerateGameClient(server.AcceptTcpClient());   //if a connection exists, the server will accept it
                Message theMessage = new Message(MessageIDs.MessageID_ClientSuccesfullyConnected, gameClient.ID, "");
                SendDataToClient(gameClient, theMessage);
                ListenToClient(gameClient);
            }
        }

        private void Server_OnClientMessage(int clientID, Message data)
        {
            if(data.MessageID==MessageIDs.MessageID_CreateGameRoom)
            {
                TheGameRoomManager.CreateRoom();
                TheGameRoomManager.AddPlayerToGameRoom(TheGameClientManager.GetGameClientFromID(clientID), 1);
            }
            if (data.MessageID == MessageIDs.MessageID_JoinGameRoom)
            {
                TheGameRoomManager.AddPlayerToGameRoom(TheGameClientManager.GetGameClientFromID(clientID), 1);
                var roomID = TheGameRoomManager.GetClientRoomID(clientID);
                var message = new Message(MessageIDs.MessageID_JoinGameRoom, clientID, "");
                SendDataToGameRoomClients(roomID,message);
            }

            if (data.MessageID == MessageIDs.MessageID_MoveAxisX)
            {
                var roomID = TheGameRoomManager.GetClientRoomID(clientID);
                var message = new Message(MessageIDs.MessageID_MoveAxisX, clientID, "");
                SendDataToGameRoomClients(roomID, message);
            }
        }

        public void ListenToClient(GameClient client)
        {
            Thread listeningThread = new Thread(new ThreadStart(() =>
            {
                while (client.TheTcpClient.Connected && client.TheNetworkStream.DataAvailable)  //while the client is connected, we look for incoming messages
                {
                    byte[] msg = new byte[1024];     //the messages arrive as byte array
                    client.TheNetworkStream.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
                    var message = new Serializer().FromByteArray<Message>(msg);

                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(msg).Trim()); //now , we write the message as string
                    if(OnClientMessage!=null)
                    {
                        OnClientMessage(client.ID,message);
                    }
                    client.TheNetworkStream.Flush();
                }
            }));
            listeningThread.Start();
        }

        public void SendDataToClient(GameClient theGameClient, Message data)
        {
            Serializer serializer = new Serializer();
            var theData = serializer.ObjectToByteArray(data);
            theGameClient.TheNetworkStream.Write(theData, 0, theData.Length);     //sending the message
        }

        public void SendDataToGameRoomClients(int roomID, Message data)
        {
            var gameClients = TheGameRoomManager.GetGameClientsInRoom(roomID);
            foreach (var client in gameClients)
            {
                var message = new Message(MessageIDs.MessageID_JoinGameRoom, client.ID, "");
                SendDataToClient(client, message);
            }
        }
    }
}
