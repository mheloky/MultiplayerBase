﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCPIPGame;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSockets
{
   /* public class Laputa : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data == "BALUS"
                      ? "I've been balused already..."
                      : "I'm not available now.";

            Send(msg);
        }
    }*/

    public class Program
    {
        public static void Main(string[] args)
        {

            /*TcpListener server = new TcpListener(IPAddress.Any, 80);
            
            // we set our IP address as server's address, and we also set the port: 9999

            server.Start();  // this will start the server

            while (true)   //we wait for a connection
            {
                TcpClient client = server.AcceptTcpClient();  //if a connection exists, the server will accept it

                NetworkStream ns = client.GetStream(); //networkstream is used to send/receive messages

                byte[] hello = new byte[100];   //any message must be serialized (converted to byte array)
                hello = Encoding.Default.GetBytes("hello world");  //conversion string => byte array

                ns.Write(hello, 0, hello.Length);     //sending the message

                while (client.Connected)  //while the client is connected, we look for incoming messages
                {
                    byte[] msg = new byte[1024];     //the messages arrive as byte array
                    ns.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(msg).Trim()); //now , we write the message as string
                }
            }*/

            Server theServer = new Server();
            theServer.Initialize();

        }
    }
}
