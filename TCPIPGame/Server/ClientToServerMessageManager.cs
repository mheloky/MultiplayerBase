using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;
using TCPIPGame.Server;

namespace TCPIPGame.Server
{
    public class ClientToServerMessenger
    {
        public void OnClientMessage_MessageConnectToServerRequest(int clientID, MessageConnectToServerRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            var gameClient = gameClientManager.GetGameClientFromID(clientID);
            var messageResponseWithClientID = new MessageConnectToServerResponse(clientID);
            SendDataToClient(gameClient, messageResponseWithClientID);
        }

        public void SendDataToClient(GameClient theGameClient, AServerMessage data)
        {
            Serializer serializer = new Serializer();
            var theData = serializer.ObjectToByteArray(data);
            theGameClient.TheNetworkStream.Write(theData, 0, theData.Length);     //sending the message
        }

        public void SendDataToGameRoomClients(int roomID, ServerMessage data, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            var gameClientIDs = gameRoomManager.GetGameClientsInRoom(roomID);
            foreach (var clientIDs in gameClientIDs)
            {
                var client = gameClientManager.GetGameClientFromID(clientIDs);
                var message = new ServerMessage(data.MessageID, client.ID, data.TheMessage);
                //SendDataToClient(client, message);
            }
        }

        public void Server_OnClientMessage() 
        {
            /*if (clientDataMessage.MessageID == MessageIDs.MessageID_CreateGameRoom)
            {
                var roomID = gameRoomManager.CreateRoom(2, (string)clientDataMessage.TheMessage);

                gameRoomManager.AddPlayerToGameRoom(clientID, roomID, 0);
                var serverMessage = new ServerMessage(MessageIDs.MessageID_CreateGameRoom, clientID, 1);

                SendDataToGameRoomClients(roomID, serverMessage, gameRoomManager, gameClientManager);
            }

            if (clientDataMessage.MessageID == MessageIDs.MessageID_JoinGameRoom)
            {
                gameRoomManager.AddPlayerToGameRoom(clientID, (int)clientDataMessage.TheMessage, 1);
                var sererMessage = new ServerMessage(MessageIDs.MessageID_JoinGameRoom, clientID, clientDataMessage.TheMessage);
                SendDataToGameRoomClients((int)clientDataMessage.TheMessage, sererMessage, gameRoomManager, gameClientManager);
            }

            if (clientDataMessage.MessageID == MessageIDs.MessageID_MoveAxisX)
            {
                var roomID = gameRoomManager.GetClientRoomID(clientID);
                var message = new ServerMessage(MessageIDs.MessageID_MoveAxisX, clientID, clientDataMessage.TheMessage);
                SendDataToGameRoomClients(roomID, message,gameRoomManager,gameClientManager);
            }

            if (clientDataMessage.MessageID == MessageIDs.MessageID_GetServerGameRooms)
            {
                var roomID = gameRoomManager.
                var message = new ServerMessage(MessageIDs.MessageID_GetServerGameRooms, clientID, clientDataMessage.TheMessage);
                SendDataToGameRoomClients(roomID, message, gameRoomManager, gameClientManager);
            }*/
        }
    }
}
