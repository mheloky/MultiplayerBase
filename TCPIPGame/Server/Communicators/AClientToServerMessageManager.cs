﻿using System;
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
        void OnClientMessage_MessageGetGameRoomPlayersRequest(int clientID, MessageGetGameRoomPlayersRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
        void OnClientMessage_MessageJoinGameRoomRequest(int clientID, MessageJoinGameRoomRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
        void OnClientMessage_MessageSendGameRoomTextMessageRequest(int clientID, MessageSendGameRoomTextMessageRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
        void OnClientMessage_MessageGetGameRoomsRequest(int clientID, MessageGetGameRoomsRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
        void OnClientMessage_MessageSendUserInputRequest(int clientID, MessageSendUserInputRequest message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
        void OnClientMessage_MessageLowLevelMessageRequest(int clientID, byte[] message, GameRoomManager gameRoomManager, GameClientManager gameClientManager);
    }
}
