using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TCPIPGame.Messages;

namespace TCPIPGame.Server
{
    public class ClientToServerListener
    {
        public delegate void DelegateOnClientMessage(int clientID, IClientMessage message);
        public event DelegateOnClientMessage OnClientMessage;

        public void ListenToClient(GameClient client)
        {
            Thread listeningThread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    if (client.TheTcpClient.Connected  /* && client.TheNetworkStream.DataAvailable*/)  //while the client is connected, we look for incoming messages
                    {
                        byte[] msg = new byte[1024];     //the messages arrive as byte array
                        client.TheNetworkStream.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client

                        if (msg.Any(x => x != 0))
                        {
                            


                            var message = new Serializer().FromByteArray<IClientMessage>(msg);

                            Console.WriteLine(message); //now , we write the message as string
                            if (OnClientMessage != null)
                            {
                                OnClientMessage(client.ID, message);
                            }
                        }
                        client.TheNetworkStream.Flush();
                    }
                }
            }));
            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

    }
}
