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
    public class ServerToClientMessageListener: IServerToClientMessageListener
    {
        #region Events
        public event EventHandler<AServerMessage> OnReceivedServerMessage;
        #endregion

        public void ListenAsync(TcpClient TheTcpClient)
        {
            new Thread(() =>
            {
                Listen(TheTcpClient);
            }).Start();
        }

        private void Listen(TcpClient TheTcpClient)
        {
            var nwStream = TheTcpClient.GetStream();
            var theSerializer = new Serializer();

            while (true)
            {
                if (TheTcpClient.Connected && nwStream.DataAvailable)
                {
                    var bytesToRead = new byte[TheTcpClient.ReceiveBufferSize];
                    nwStream.Read(bytesToRead, 0, TheTcpClient.ReceiveBufferSize);
                    var serverMessage = theSerializer.FromByteArray<AServerMessage>(bytesToRead);

                    if (OnReceivedServerMessage != null)
                    {
                        OnReceivedServerMessage(null, serverMessage);
                    }

                }
            }
        }
    }
}
