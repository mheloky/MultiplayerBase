using System.Collections.Generic;
using System.Linq;
using TCPIPGame.Messages;
using TCPIPGame.Server.DomainObjects;
using TCPIPGame.Server.GameStructure;

namespace TCPIPGame.Server
{
    public class ClientToServerMessageManager :AClientToServerMessageManager
    {
        public void OnClientMessage_MessageConnectToServerRequest(int clientID, MessageConnectToServerRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            var gameClient = gameClientManager.GetGameClientFromClientID(clientID);
            gameClient.Name = message.Name;
            var messageResponseWithClientID = new MessageConnectToServerResponse(clientID,message.Name);
            SendDataToClient(gameClient, messageResponseWithClientID);
        }

        public void OnClientMessage_MessageCreateRoomRequest(int clientID, MessageCreateRoomRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            var gameClient = gameClientManager.GetGameClientFromClientID(clientID);
            var gameRoomHost = new Player(gameClient.ID, gameClient.Name);
            var  roomID=gameRoomManager.CreateRoom(2, message.RoomName, clientID);
            var messageResponse = new MessageCreateRoomResponse(message.RoomName, roomID, gameRoomHost);
            SendDataToClient(gameClient, messageResponse);
        }

        public void OnClientMessage_MessageGetGameRoomHostRequest(int clientID, MessageGetGameRoomHostRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            var roomHostClientID = gameRoomManager.GetGameRoomHostClientIDFromGameRoomID(message.RoomID);
            var client = gameClientManager.GetGameClientFromClientID(roomHostClientID);
            var gameRoomHost = new Player(client.ID, client.Name);
            var messageResponse = new MessageGetGameRoomHostResponse(gameRoomHost);

            var gameClient = gameClientManager.GetGameClientFromClientID(clientID);
            SendDataToClient(gameClient, messageResponse);
        }

        public void OnClientMessage_MessageGetGameRoomPlayersRequest(int clientID, MessageGetGameRoomHostRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            var roomID = message.RoomID;
            var roomHostClientID = gameRoomManager.GetGameRoomHostClientIDFromGameRoomID(message.RoomID);

            var players = new List<APlayer>();
            var playerManager = new PlayerManager();
            players.Add(playerManager.GetPlayerFromClientID(roomHostClientID, gameClientManager)); //the first clientID will be the host


            var clientIDs=gameRoomManager.GetGameClientsInRoom(roomID);
            for(int i=0;i<clientIDs.Count;i++)
            {
                if(clientIDs[i]!= roomHostClientID)
                {
                    players.Add(playerManager.GetPlayerFromClientID(clientIDs[i], gameClientManager));
                }
            }

            var messageResponse = new MessageGetGameRoomPlayersResponse(players);
            var gameClient = gameClientManager.GetGameClientFromClientID(clientID);
            SendDataToClient(gameClient, messageResponse);
        }

        public void OnClientMessage_MessageJoinGameRoomRequest(int clientID, MessageJoinGameRoomRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            gameRoomManager.AddPlayerToGameRoom(clientID, message.RoomID, 1);
            
            var clientIDs=gameRoomManager.GetGameClientsInRoom(message.RoomID);
            var playerThatJoined=new PlayerManager().GetPlayerFromClientID(clientID, gameClientManager);
            var theGameClients = gameClientManager.GetGameClientsFromClientIDs(clientIDs.ToList());

            SendDataToClients(theGameClients, new MessageJoinGameRoomResponse(playerThatJoined));
        }

        public void OnClientMessage_MessageSendGameRoomTextMessageRequest(int clientID, MessageSendGameRoomTextMessageRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            var roomID = gameRoomManager.GetClientRoomID(clientID);
            SendDataToClientsInRoom(roomID, gameRoomManager, gameClientManager, new MessageSendGameRoomTextMessageResponse(message.TheMessage));
        }

        public void OnClientMessage_MessageGetGameRoomsRequest(int clientID, MessageGetGameRoomsRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            var gameClient = gameClientManager.GetGameClientFromClientID(clientID);
            var gameRooms = gameRoomManager.GetGameRooms();

            var lightGameRooms = new List<TCPIPGame.Messages.GameRoom>();

            for(int i=0;i<gameRooms.Count;i++)
            {
                var roomID = gameRooms[i].ID;
                var roomName = gameRooms[i].Name;
                lightGameRooms.Add(new TCPIPGame.Messages.GameRoom(roomID, roomName));
            }

            SendDataToClient(gameClient, new MessageGetGameRoomsResponse(lightGameRooms));
        }

        public void SendDataToClient(GameClient theGameClient, AServerMessage data)
        {
            Serializer serializer = new Serializer();
            var theData = serializer.ObjectToByteArray(data);
            theGameClient.TheNetworkStream.Write(theData, 0, theData.Length);     //sending the message
        }

        public void SendDataToClients(List<GameClient> theGameClient, AServerMessage data)
        {
            Serializer serializer = new Serializer();
            var theData = serializer.ObjectToByteArray(data);

            for (int i = 0; i < theGameClient.Count; i++)
            {
                var client = theGameClient[i];
                client.TheNetworkStream.Write(theData, 0, theData.Length);     //sending the message
            }
        }

        public void SendDataToClientsInRoom(int roomID, GameRoomManager gameRoomManager, GameClientManager gameClientManager, AServerMessage data)
        {
            var clientIDs = gameRoomManager.GetGameClientsInRoom(roomID);
            var theGameClients = gameClientManager.GetGameClientsFromClientIDs(clientIDs.ToList());

            SendDataToClients(theGameClients, data);
        }
    }
}
