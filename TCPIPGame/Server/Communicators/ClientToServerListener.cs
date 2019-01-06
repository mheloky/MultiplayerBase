using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public class ClientToServerListener:AClientToServerListener
    {

        public event EventHandler<AClientMessage> OnClientMessage;
        public event Action<int,byte[]> OnLowLevelClientMessage;

        public void ListenToClient(GameClient client)
        {
            Thread listeningThread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    if (client.TheTcpClient.Connected  /* && client.TheNetworkStream.DataAvailable*/)  //while the client is connected, we look for incoming messages
                    {
                       // byte[] msg = new byte[1024];     //the messages arrive as byte array
                        if (client.TheTcpClient.ReceiveBufferSize > 0)
                        {
                            var msg = new byte[client.TheTcpClient.ReceiveBufferSize];
                            client.TheNetworkStream.Read(msg, 0, client.TheTcpClient.ReceiveBufferSize);
                            var message = new Serializer().FromByteArray<AClientMessage>(msg);

                            Console.WriteLine(message); //now , we write the message as string
                            if (OnClientMessage != null)
                            {
                                OnClientMessage(client.ID, message);
                            }
                        }
                       
                    }
                    client.TheNetworkStream.Flush();

                }
            }))
            {
                IsBackground = true
            };
            listeningThread.Start();
        }

    }
}
