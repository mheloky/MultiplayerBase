using System;
using System.Net.Sockets;

using TCPIPGame;
using TCPIPGame.Client;
using TCPIPGame.Messages;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {

            GameClient client = new GameClient();
            //client.OnPreConnectedToServerResponseReceived += Client_PreConnectedToServerSucessfully;
            //client.OnConnectedToServerResponseReceived += Client_ConnectedToServerSucessfully;

           // client.SendMessageToServer(new MessageConnectToServerRequest("Robot1"));
            //client.OnCreateGameRoomSuccessful += Client_OnCreateGameRoomSuccessful;
            /* //---data to send to the server---
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

        private static void Client_ConnectedToServerSucessfully(int clientID, bool connectionStatus)
        {
            Console.WriteLine(string.Format("Client connected"));
        }

        private static void Client_PreConnectedToServerSucessfully(bool preConnectedSucessfully)
        {
            Console.WriteLine(string.Format("Client preconnected"));
        }

        private static void Client_OnCreateGameRoomSuccessful(int clientID, bool CreateGameStatus)
        {
            Console.WriteLine(string.Format("Client ID:{0} GameCOnnected:{1}",clientID,CreateGameStatus));
        }
    }
    }
