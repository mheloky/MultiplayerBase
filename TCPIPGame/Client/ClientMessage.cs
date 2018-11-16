using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame
{
    [Serializable]
    public class ClientMessage
    {
        public int MessageID
        {
            get;
            set;
        }
        public Object TheMessage
        {
            get;
            set;
        }

        public ClientMessage(int messageID, Object data)
        {
            MessageID = messageID;
            TheMessage = data;

        }

        public override string ToString()
        {
            return String.Format("MessageID:{0}, TheMessage:{1}", MessageID, (string)TheMessage);

        }
    }
}
