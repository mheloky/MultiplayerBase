using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;


namespace TCPIPGame
{
    public class ClientGameRoomMap
    {
        Dictionary<int, Tuple<int, TcpClient>> TheDictionary = new Dictionary<int, Tuple<int, TcpClient>>();

        void AddClientGameRoom(int clientID, int gameRoom, TcpClient client)
        {
            TheDictionary.Add(clientID, new Tuple<int, TcpClient>(gameRoom, client));

        }
    }
}
