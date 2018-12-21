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
    public class ServerToClientListener
    {

        public delegate void ReceivedServerMessage(IServerMessage theServerMessage);
        public event ReceivedServerMessage OnReceivedServerMessage;

        public void Listen(TcpClient theCLient)
        {

            new Thread(() =>
            {
                var nwStream = theCLient.GetStream();
                var theSerializer = new Serializer();

                while (true)
                {
                    if (theCLient.Connected && nwStream.DataAvailable)
                    {
                        var bytesToRead = new byte[theCLient.ReceiveBufferSize];
                        nwStream.Read(bytesToRead, 0, theCLient.ReceiveBufferSize);
                        var serverMessage = theSerializer.FromByteArray<IServerMessage>(bytesToRead);

                        if (OnReceivedServerMessage != null)
                        {
                            OnReceivedServerMessage(serverMessage);
                        }

                    }
                }
            }).Start();
        }
    }
}
