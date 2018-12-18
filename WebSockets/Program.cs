 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

using TCPIPGame;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace TCPIPGame.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Server theServer = new Server();
            theServer.Initialize();

        }
    }
}
