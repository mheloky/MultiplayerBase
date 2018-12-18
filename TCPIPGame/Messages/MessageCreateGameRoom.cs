using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Messages
{
    public class MessageCreateGameRoom
    {
        public int ID=9;
        public string Name="null";

        public MessageCreateGameRoom(int id, string name)
        {
            ID = id;
            Name = name;
        }

    }
}
