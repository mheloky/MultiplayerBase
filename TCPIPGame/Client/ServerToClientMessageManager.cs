using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Client
{
    public class ServerToClientMessageManager
    {
        public delegate void ConnectedToServerSuccessfully(int clientID, bool ConnectionStatus);
        public event ConnectedToServerSuccessfully OnConnectedToServerSuccessfully;

        public delegate void CreateGameRoomSuccessful(int clientID, bool CreateGameStatus);
        public event CreateGameRoomSuccessful OnCreateGameRoomSuccessful;

        public delegate void JoinGameRoomSuccessful(int clientID, int roomID);
        public event JoinGameRoomSuccessful OnJoinGameRoomSuccessful;

        public void Server_OnClientMessage(ServerMessage serverDataMessage)
        {
            if (OnConnectedToServerSuccessfully != null && serverDataMessage.MessageID == MessageIDs.MessageID_ClientSuccesfullyConnected)
            {
                OnConnectedToServerSuccessfully(serverDataMessage.ClientSenderID, true);
            }

            if (OnCreateGameRoomSuccessful!=null && serverDataMessage.MessageID == MessageIDs.MessageID_CreateGameRoom)
            {
                OnCreateGameRoomSuccessful(serverDataMessage.ClientSenderID, true);
            }

            if (OnJoinGameRoomSuccessful!=null && serverDataMessage.MessageID == MessageIDs.MessageID_JoinGameRoom)
            {
                var roomID=(int)serverDataMessage.TheMessage;
                OnJoinGameRoomSuccessful(serverDataMessage.ClientSenderID, roomID);
            }
        }
    }
}
