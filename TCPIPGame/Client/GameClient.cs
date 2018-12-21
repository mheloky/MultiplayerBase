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

        private ServerToClientMessageTranslator TheServerToClientMessageTranslator
        {
            get;
            set;
        }

        private ServerToClientMessageManager TheServerToClientMessageManager
        {
            get;
            set;
        }

        public bool IsPreConnected
        {
            get;
            set;
        }

        public bool IsConnected
        {
            get;
            set;
        }

        public int ClientID
        {
            get;
            private set;
        }

        const int PORT_NO = 80;
        //const string SERVER_IP = "104.168.133.156";
        const string SERVER_IP = "localhost";

        public delegate void ConnectedToServerSuccessfully(int clientID, bool ConnectionStatus);
        public event ConnectedToServerSuccessfully OnConnectedToServerSuccessfully;

        public delegate void CreateGameRoomSuccessful(int clientID, bool CreateGameStatus);
        public event CreateGameRoomSuccessful OnCreateGameRoomSuccessful;
        #endregion

        #region events
        public delegate void _preConnectedToServerSucessfully(bool preConnectedSucessfully);
        public event _preConnectedToServerSucessfully PreConnectedToServerSucessfully;

        public delegate void _connectedToServerSucessfully(int clientID);
        public event _connectedToServerSucessfully ConnectedToServerSucessfully;

        #endregion

        public GameClient()
        {
            #region Init
            TheServerToClientMessageManager = new ServerToClientMessageManager();
            TheServerToClientMessageTranslator = new ServerToClientMessageTranslator();
            TheServerToClientListener = new ServerToClientListener();
            #endregion 

            TheTcpClient = new TcpClient(SERVER_IP, PORT_NO);
            TheServerToClientListener.Listen(TheTcpClient);

            TheServerToClientListener.OnReceivedServerMessage += TheServerToClientListener_OnReceivedServerMessage;
            TheServerToClientMessageTranslator.TranslatedMessageToMessageConnectToServerResponse += TheServerToClientMessageTranslator_TranslatedMessageToMessageConnectToServerResponse;
            TheServerToClientMessageTranslator.TranslatedMessageToMessagePreConnectToServerResponse += TheServerToClientMessageTranslator_TranslatedMessageToMessagePreConnectToServerResponse;

            //TheServerToClientMessageManager.OnCreateGameRoomSuccessful += TheServerToClientMessageManager_OnCreateGameRoomSuccessful;
        }

        private void TheServerToClientMessageTranslator_TranslatedMessageToMessageConnectToServerResponse(MessageConnectToServerResponse message)
        {
            ClientID = message.ClientID;
            
            if(ConnectedToServerSucessfully!=null)
            {
                ConnectedToServerSucessfully(message.ClientID);
            }
        }

        private void TheServerToClientMessageTranslator_TranslatedMessageToMessagePreConnectToServerResponse(MessagePreConnectToServerResponse message)
        {
            var preConnectedSucesfully = message.Connected;
            IsPreConnected = preConnectedSucesfully;
            if (PreConnectedToServerSucessfully != null)
            {
                PreConnectedToServerSucessfully(preConnectedSucesfully);
            }
        }

        private void TheServerToClientMessageManager_OnCreateGameRoomSuccessful(int clientID, bool CreateGameStatus)
        {
            if (OnCreateGameRoomSuccessful != null)
            {
                OnCreateGameRoomSuccessful(clientID, CreateGameStatus);
            }
        }

        public void SendMessageToServer(IClientMessage theClientMessage)
        {
            var nwStream = TheTcpClient.GetStream();
            var theSerializer = new Serializer();
            var bytesToRead = theSerializer.ObjectToByteArray(theClientMessage);
            nwStream.Write(bytesToRead, 0, bytesToRead.Length);
        }

        private void TheServerToClientListener_OnReceivedServerMessage(IServerMessage theServerMessage)
        {
            TheServerToClientMessageTranslator.TranslateMessage(theServerMessage);
        }

    }
}
