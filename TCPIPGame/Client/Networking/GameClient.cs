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

        public AGameClientStatus TheGameClientStatus
        {
            get;
            private set;
        }
        private TcpClient TheTcpClient
        {
            get;
            set;
        }
        private IServerToClientMessageManager TheServerToClientMessageManager
        {
            get;
            set;
        }
        private AServerToClientMessageTranslator TheServerToClientMessageTranslator
        {
            get;
            set;
        }
        #endregion
        #region Events
        /// <summary>
        /// Initial call to the server to see if the server will take requests
        /// </summary>
        public event EventHandler<AGameClientStatus> OnPreConnectedToServerResponseReceived;

        /// <summary>
        /// The server has taken your request to join it
        /// </summary>
        public event EventHandler<AGameClientStatus> OnConnectedToServerResponseReceived;

        public event EventHandler<MessageCreateRoomResponse> OnCreateGameRoomSuccessful;
        #endregion

        public GameClient()
        {
            TheGameClientStatus = new GameClientStatus();
            TheTcpClient = new TcpClient(_serverIP, _portNumber);
            TheServerToClientMessageManager = new ServerToClientMessageManager(TheTcpClient, TheServerToClientMessageTranslator);

            SetupEvents();
        }

        public void SendMessageToServer(AClientMessage message)
        {
            TheServerToClientMessageManager.SendMessageToServer(message);
        }

        #region Helper Methods
        private void SetupEvents()
        {
            TheServerToClientMessageTranslator.Event_OnPreConnectToServerResponseTranslated += Trigger_OnPreConnectedToServerResponseReceived;
            TheServerToClientMessageTranslator.Event_OnConnectToServerResponseTranslated += Trigger_OnConnectedToServerResponseReceived;
            //TheServerToClientMessageManager.OnCreateGameRoomSuccessful += TheServerToClientMessageManager_OnCreateGameRoomSuccessful;
        }
        #endregion
        #region Trigger Events (Trigger Events that higher level classes subscribed to this class receive)
        private void Trigger_OnConnectedToServerResponseReceived(object sender, MessageConnectToServerResponse message)
        {
            TheGameClientStatus.SetClientID(message.ClientID);

            if (OnConnectedToServerResponseReceived != null)
            {
                OnConnectedToServerResponseReceived(message.ClientID, TheGameClientStatus);
            }
        }

        private void Trigger_OnPreConnectedToServerResponseReceived(object sender, MessagePreConnectToServerResponse message)
        {
            var preConnectedSucesfully = message.Connected;
            TheGameClientStatus.SetIsPreConnected(preConnectedSucesfully);
            if (OnPreConnectedToServerResponseReceived != null)
            {
                OnPreConnectedToServerResponseReceived(null, TheGameClientStatus);
            }
        }

        private void Trigger_OnCreateGameRoomSuccessful(int clientID, bool CreateGameStatus)
        {
            if (OnCreateGameRoomSuccessful != null)
            {
                //OnCreateGameRoomSuccessful(null, TheGameClientStatus);
            }
        }
        #endregion
    }
}
