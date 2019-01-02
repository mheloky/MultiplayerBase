using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPIPGame.Server;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class MessageSendUserInputRequest : AClientMessage
    {
        public UserInput TheUserInput
        {
            get;
            set;
        }

        public MessageSendUserInputRequest(UserInput userInput)
        {
            TheUserInput = userInput;
        }

        public override void Translate(int clientID, AClientToServerMessageTranslator translator)
        {
            translator.TranslateMessage(clientID, this);
        }
    }
}
