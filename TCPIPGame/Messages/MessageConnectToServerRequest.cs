using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Messages
{
    public class MessageConnectToServerRequest
    {
        public string Name
        {
            get;
            set;
        }

        public MessageConnectToServerRequest(string name)
        {
            Name = name;
        }
    }
}
