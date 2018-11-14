using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPIPGame
{
    [Serializable]
    public class ServerMessage
    {
        public int MessageID
        {
            get;
            set;
        }
        public int ClientSenderID
        {
            get;
            set;
        }
        public Object TheMessage
        {
            get;
            set;
        }

        public ServerMessage(int messageID, int clientSenderID, Object data)
        {
            MessageID = messageID;
            ClientSenderID = clientSenderID;
            TheMessage = data;

        }

        public override string ToString()
        {
            return String.Format("MessageID:{0}, ClientSenderID:{1}, TheMessage:{2}", MessageID, ClientSenderID, (string)TheMessage);

        }
    }
}
