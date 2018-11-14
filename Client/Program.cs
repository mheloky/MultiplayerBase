using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCPIPGame;
using WebSocketSharp;

namespace Client
{
    public class Program
    {
        const int PORT_NO = 80;
        //const string SERVER_IP = "104.168.133.156";
        const string SERVER_IP = "localhost";



        static void Main(string[] args)
        {
            //---data to send to the server---
            string textToSend = DateTime.Now.ToString();

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            Serializer theSerializer = new Serializer();

            while (true)
            {

                if(client.Connected && nwStream.DataAvailable)
                {
                    var bytesToRead = new byte[client.ReceiveBufferSize];
                     nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize); 
                    Console.WriteLine("Received : " + theSerializer.FromByteArray<ServerMessage>(bytesToRead));
                }

                var readLine = "";
                if(readLine=="0")
                {
                    var theMessage = new ClientMessage(MessageIDs.MessageID_CreateGameRoom, "");
                    var bytesToRead = theSerializer.ObjectToByteArray(theMessage);
                    nwStream.Write(bytesToRead, 0, bytesToRead.Length);
                }

                if (readLine == "1")
                {
                    var theMessage = new ClientMessage(MessageIDs.MessageID_JoinGameRoom, "");
                    var bytesToRead = theSerializer.ObjectToByteArray(theMessage);
                    nwStream.Write(bytesToRead, 0, bytesToRead.Length);
                }


                /*
                  var readline = Console.ReadLine();
                if(readline=="0")
                {

                }

                  Console.WriteLine("Sending : " + textToSend);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                //---send the text---
                Console.WriteLine("Sending : " + textToSend);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                //---read back the text---
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
                Console.ReadLine();
                client.Close();*/
            }
        }
    }
}
