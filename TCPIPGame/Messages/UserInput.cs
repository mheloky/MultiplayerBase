using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class UserInput
    {
        public float HorizontalAxis
        {
            get;
            set;
        }
        public bool Jump
        {
            get;
            set;
        }

        public UserInput(float horizontalAxis=0, bool jump=false)
        {

        }

    }
}
