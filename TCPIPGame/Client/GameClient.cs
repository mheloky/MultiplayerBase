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
        const int _portNumber = 80;
        //const string SERVER_IP = "104.168.133.156";
        const string _serverIP = "localhost";

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
        #endregion

        #region events
        public delegate void _preConnectedToServerSucessfully(bool preConnectedSucessfully);
        /// <summary>
        /// Initial call to the server to see if the server will take requests
        /// </summary>
        public event _preConnectedToServerSucessfully OnPreConnectedToServerResponseReceived;

        public delegate void _connectedToServerSucessfully(int clientID, bool preConnectedSucessfully);
        /// <summary>
        /// The server has taken your request to join it
        /// </summary>
        public event _connectedToServerSucessfully OnConnectedToServerResponseReceived;

        public delegate void CreateGameRoomSuccessful(int clientID, bool CreateGameStatus);
        public event CreateGameRoomSuccessful OnCreateGameRoomSuccessful;
        #endregion

        public GameClient()
        {
            Init();

            TheTcpClient = new TcpClient(_serverIP, _portNumber);
            TheServerToClientListener.Listen(TheTcpClient);

            SetupEvents();
        }

        public void SendMessageToServer(IClientMessage theClientMessage)
        {
            var nwStream = TheTcpClient.GetStream();
            var theSerializer = new Serializer();
            var bytesToRead = theSerializer.ObjectToByteArray(theClientMessage);
            nwStream.Write(bytesToRead, 0, bytesToRead.Length);
        }

        /// <summary>
        /// Messages Received from Server Gets Translated
        /// </summary>
        /// <param name="theServerMessage"></param>
        private void OnReceivedServerMessage(IServerMessage theServerMessage)
        {
            TheServerToClientMessageTranslator.TranslateMessage(theServerMessage);
        }

        #region Helper Methods

        #region Setup
        /// <summary>
        /// Initialized Variables
        /// </summary>
        private void Init()
        {
            TheServerToClientMessageManager = new ServerToClientMessageManager();
            TheServerToClientMessageTranslator = new ServerToClientMessageTranslator();
            TheServerToClientListener = new ServerToClientListener();
        }

        /// <summary>
        /// Setups The Events to Trigger
        /// </summary>
        private void SetupEvents()
        {
            TheServerToClientListener.OnReceivedServerMessage += OnReceivedServerMessage;
            TheServerToClientMessageTranslator.TranslatedMessageToMessageConnectToServerResponse += Trigger_OnConnectedToServerResponseReceived;
            TheServerToClientMessageTranslator.TranslatedMessageToMessagePreConnectToServerResponse += Trigger_OnPreConnectedToServerResponseReceived;
            //TheServerToClientMessageManager.OnCreateGameRoomSuccessful += TheServerToClientMessageManager_OnCreateGameRoomSuccessful;
        }
        #endregion

        #region Trigger Events (Trigger Events that higher level classes subscribed to this class receive)
        private void Trigger_OnConnectedToServerResponseReceived(MessageConnectToServerResponse message)
        {
            ClientID = message.ClientID;

            if (OnConnectedToServerResponseReceived != null)
            {
                OnConnectedToServerResponseReceived(message.ClientID, true);
            }
        }

        private void Trigger_OnPreConnectedToServerResponseReceived(MessagePreConnectToServerResponse message)
        {
            var preConnectedSucesfully = message.Connected;
            IsPreConnected = preConnectedSucesfully;
            if (OnPreConnectedToServerResponseReceived != null)
            {
                OnPreConnectedToServerResponseReceived(preConnectedSucesfully);
            }
        }

        private void Trigger_OnCreateGameRoomSuccessful(int clientID, bool CreateGameStatus)
        {
            if (OnCreateGameRoomSuccessful != null)
            {
                OnCreateGameRoomSuccessful(clientID, CreateGameStatus);
            }
        }
        #endregion

        #endregion
    }
}
