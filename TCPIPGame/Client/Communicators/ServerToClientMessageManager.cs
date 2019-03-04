using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TCPIPGame.Messages;
using TCPIPGame.Server;

namespace TCPIPGame.Client
{
    public class ServerToClientMessageManager: IServerToClientMessageManager
    {
        #region Properties
        private TcpClient TheTcpClient
        {
            get;
            set;
        }
        private AServerToClientMessageTranslator TheServerToClientMessageTranslator
        {
            get;
            set;
        }

        private AServerToClientMessageListener TheServerToClientMessageListener
        {
            get;
            set;
        }
        #endregion

        public ServerToClientMessageManager(TcpClient client, AServerToClientMessageTranslator serverToClientMessageTranslator)
        {
            TheTcpClient = client;
            TheServerToClientMessageListener = new ServerToClientMessageListener() ;
            TheServerToClientMessageListener.OnReceivedServerMessage += OnReceivedServerMessage;
            TheServerToClientMessageListener.OnReceivedServerLowLevelMessage += OnReceivedServerLowLevelMessage;
            TheServerToClientMessageTranslator = serverToClientMessageTranslator;
            TheServerToClientMessageListener.ListenAsync(client);
        }

        private void OnReceivedServerMessage(object sender, AServerMessage theServerMessage)
        {
            TheServerToClientMessageTranslator.TranslateMessage(theServerMessage);
        }

        private void OnReceivedServerLowLevelMessage(int clientID, byte[] data)
        {
            var userInput = new NetworkUserInput(data);
            var message = new MessageSendUserInputResponse(clientID, userInput);
            TheServerToClientMessageTranslator.TranslateMessage(message);
        }

        public void SendMessageToServer(AClientMessage theClientMessage)
        {
            var nwStream = TheTcpClient.GetStream();
            var theSerializer = new Serializer();
            var bytesToRead = theSerializer.ObjectToByteArray(theClientMessage);
            nwStream.Write(bytesToRead, 0, bytesToRead.Length);
        }

        public void SendLowLevelMessageToServer(byte[] theClientMessage)
        {
            var nwStream = TheTcpClient.GetStream();
            nwStream.Write(theClientMessage, 0, theClientMessage.Length);
        }
    }
}
