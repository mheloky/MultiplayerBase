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
        public event EventHandler<MessagePreConnectToServerResponse> OnPreConnectedToServerResponseReceived;
        /// <summary>
        /// The server has taken your request to join it
        /// </summary>
        public event EventHandler<MessageConnectToServerResponse> OnConnectedToServerResponseReceived;
        public event EventHandler<MessageCreateRoomResponse> OnCreateGameRoomSuccessful;
        public event EventHandler<MessageGetGameRoomHostResponse> OnGetGameRoomHostRequestSuccessful;
        public event EventHandler<MessageJoinGameRoomResponse> OnJoinGameRoomRequestSuccessful;
        #endregion

        public GameClient()
        {
            TheGameClientStatus = new GameClientStatus();
            TheTcpClient = new TcpClient(_serverIP, _portNumber);
            TheServerToClientMessageTranslator = new ServerToClientMessageTranslator();
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
            TheServerToClientMessageTranslator.Event_OnCreateRoomServerResponseTranslated += TheServerToClientMessageTranslator_Event_OnCreateRoomServerResponseTranslated;
            TheServerToClientMessageTranslator.Event_OnGetGameRoomHostResponseTranslated += TheServerToClientMessageTranslator_Event_OnGetGameRoomHostRequestTranslated;
            TheServerToClientMessageTranslator.Event_OnJoinGameRoomResponseTranslated += TheServerToClientMessageTranslator_Event_OnJoinGameRoomResponseTranslated;
        }

        #endregion
        #region Trigger Events (Trigger Events that higher level classes subscribed to this class receive)


        private void Trigger_OnPreConnectedToServerResponseReceived(object sender, MessagePreConnectToServerResponse message)
        {
            if (OnPreConnectedToServerResponseReceived != null)
            {
                OnPreConnectedToServerResponseReceived(null, message);
            }
        }

        private void Trigger_OnConnectedToServerResponseReceived(object sender, MessageConnectToServerResponse message)
        {
            if (OnConnectedToServerResponseReceived != null)
            {
                OnConnectedToServerResponseReceived(message.ClientID, message);
            }
        }


        private void TheServerToClientMessageTranslator_Event_OnCreateRoomServerResponseTranslated(object sender, MessageCreateRoomResponse e)
        {
            if (OnCreateGameRoomSuccessful != null)
            {
                OnCreateGameRoomSuccessful(null, e);
            }
        }

        private void TheServerToClientMessageTranslator_Event_OnGetGameRoomHostRequestTranslated(object sender, MessageGetGameRoomHostResponse e)
        {
            if (OnGetGameRoomHostRequestSuccessful != null)
            {
                OnGetGameRoomHostRequestSuccessful(null, e);
            }
        }

        private void TheServerToClientMessageTranslator_Event_OnJoinGameRoomResponseTranslated(object sender, MessageJoinGameRoomResponse e)
        {
            if (OnJoinGameRoomRequestSuccessful != null)
            {
                OnJoinGameRoomRequestSuccessful(null, e);
            }
        }

        #endregion
    }
}
