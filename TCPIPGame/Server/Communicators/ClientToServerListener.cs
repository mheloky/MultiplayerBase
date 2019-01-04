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
                        byte[] msg = new byte[1024];     //the messages arrive as byte array
                        var bytesSize=client.TheNetworkStream.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client

                       // byte[] msg2 = new byte[2];     //the messages arrive as byte array
                        //var bytesSize2 = client.TheNetworkStream.Read(msg2, 0, msg2.Length);

                        if (msg.Count(x=>x!=0) <=2)
                        {
                            var extractedByteData = new byte[] { (byte)client.ID, msg[0],msg[1] };
                            OnLowLevelClientMessage(client.ID, extractedByteData);
                        }
                        else if (msg.Any(x => x != 0))
                        {
                            var message = new Serializer().FromByteArray<AClientMessage>(msg);

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
