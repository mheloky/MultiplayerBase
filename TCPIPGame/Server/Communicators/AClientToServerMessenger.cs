using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public interface AClientToServerMessenger
    {
        void SendDataToClient(GameClient theGameClient, AServerMessage data);
        void OnClientMessage_MessageConnectToServerRequest(int clientID, MessageConnectToServerRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
    }
}
