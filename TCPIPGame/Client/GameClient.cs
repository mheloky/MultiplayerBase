using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TCPIPGame.Client;
using TCPIPGame.Messages;

namespace TCPIPGame.Client
{
    public class GameClient
    {
        #region Properties
        private TcpClient TheTcpClient
        {
            get;
            set;
        }

        private ServerToClientListener TheServerToClientListener
        {
            get;
            set;
        }

        private ServerToClientMessageManager TheServerToClientMessageManager
        {
            get;
            set;
        }

        public bool IsConnected
        {
            get;
            set;
        }

        const int PORT_NO = 80;
        //const string SERVER_IP = "104.168.133.156";
        const string SERVER_IP = "localhost";

        public delegate void ConnectedToServerSuccessfully(int clientID, bool ConnectionStatus);
        public event ConnectedToServerSuccessfully OnConnectedToServerSuccessfully;

        public delegate void CreateGameRoomSuccessful(int clientID, bool CreateGameStatus);
        public event CreateGameRoomSuccessful OnCreateGameRoomSuccessful;
        #endregion

        public GameClient()
        {
            TheTcpClient = new TcpClient(SERVER_IP, PORT_NO);

            TheServerToClientMessageManager = new ServerToClientMessageManager();

            TheServerToClientListener = new ServerToClientListener();
            TheServerToClientListener.Listen(TheTcpClient);

            TheServerToClientListener.OnReceivedServerMessage += TheServerToClientMessageManager.Server_OnClientMessage;
            TheServerToClientMessageManager.OnCreateGameRoomSuccessful += TheServerToClientMessageManager_OnCreateGameRoomSuccessful;

            TheServerToClientListener.OnReceivedServerMessage += TheServerToClientMessageManager.Server_OnClientMessage;
            TheServerToClientMessageManager.OnConnectedToServerSuccessfully += TheServerToClientMessageManager_OnConnectedToServerSuccessfully; ;
        }

        private void TheServerToClientMessageManager_OnConnectedToServerSuccessfully(int clientID, bool ConnectionStatus)
        {
            IsConnected = true;
            if (OnConnectedToServerSuccessfully != null)
            {
                OnConnectedToServerSuccessfully(clientID, ConnectionStatus);
            }
        }

        private void TheServerToClientMessageManager_OnCreateGameRoomSuccessful(int clientID, bool CreateGameStatus)
        {
            
            if (OnCreateGameRoomSuccessful != null)
            {
                OnCreateGameRoomSuccessful(clientID, CreateGameStatus);
            }
        }

        public void SendMessage(IMessage theClientMessage)
        {
            var nwStream = TheTcpClient.GetStream();
            var theSerializer = new Serializer();
            var bytesToRead = theSerializer.ObjectToByteArray(theClientMessage);
            nwStream.Write(bytesToRead, 0, bytesToRead.Length);
        }
    }
}
