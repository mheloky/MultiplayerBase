using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;
using TCPIPGame.Server;

namespace TCPIPGame.Server
{
    public class ClientToServerMessenger:AClientToServerMessenger
    {
        public void OnClientMessage_MessageConnectToServerRequest(int clientID, MessageConnectToServerRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager)
        {
            var gameClient = gameClientManager.GetGameClientFromID(clientID);
            gameClient.Name = message.Name;
            var messageResponseWithClientID = new MessageConnectToServerResponse(clientID,message.Name);
            SendDataToClient(gameClient, messageResponseWithClientID);
        }

        public void SendDataToClient(GameClient theGameClient, AServerMessage data)
        {
            Serializer serializer = new Serializer();
            var theData = serializer.ObjectToByteArray(data);
            theGameClient.TheNetworkStream.Write(theData, 0, theData.Length);     //sending the message
        }
    }
}
