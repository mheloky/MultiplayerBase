using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;
using TCPIPGame.Server;
using TCPIPGame.Server.DomainObjects;

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
            var gameClient = gameClientManager.GetGameClientFromClientID(clientID);
            var roomHostClientID = gameRoomManager.GetGameRoomHostClientIDFromGameRoomID(message.RoomID);
            var client = gameClientManager.GetGameClientFromClientID(roomHostClientID);
            var gameRoomHost = new Player(client.ID, client.Name);
            var messageResponse = new MessageGetGameRoomHostResponse(gameRoomHost);
            SendDataToClient(gameClient, messageResponse);
        }

        public void SendDataToClient(GameClient theGameClient, AServerMessage data)
        {
            Serializer serializer = new Serializer();
            var theData = serializer.ObjectToByteArray(data);
            theGameClient.TheNetworkStream.Write(theData, 0, theData.Length);     //sending the message
        }
    }
}
