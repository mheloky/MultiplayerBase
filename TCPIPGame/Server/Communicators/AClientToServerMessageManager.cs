using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public interface AClientToServerMessageManager
    {
        void SendDataToClient(GameClient theGameClient, AServerMessage data);
        void OnClientMessage_MessageConnectToServerRequest(int clientID, MessageConnectToServerRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
        void OnClientMessage_MessageCreateRoomRequest(int clientID, MessageCreateRoomRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
        void OnClientMessage_MessageGetGameRoomHostRequest(int clientID, MessageGetGameRoomHostRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
    }
}
