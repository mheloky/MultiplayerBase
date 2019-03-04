using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPIPGame.Messages
{
    [Serializable]
    public class NetworkUserInput
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

        public float PositionX
        {
            get;
            set;
        }

        public float PositionY
        {
            get;
            set;
        }

        public NetworkUserInput(float positionX, float positionY, float horizontalAxis=0, bool jump=false)
        {
            HorizontalAxis = horizontalAxis;
            Jump = jump;

            PositionX = positionX;
            PositionY = positionY;
        }

        public NetworkUserInput(byte[] data)
        {
            //Horizontal Axis
            if(data[0]==0)
            {
                HorizontalAxis = -1;
            }
            if (data[0] == 1)
            {
                HorizontalAxis = 0;
            }
            if (data[0] == 2)
            {
                HorizontalAxis = 1;
            }

            //Jump
            if (data[1] == 0)
            {
                Jump = false;
            }
            if (data[1] == 1)
            {
                Jump = true;
            }
        }

        public byte[] GetLowLevelData()
        {
            byte horizontalAxis = 0;
            byte jump = 0;

            if (HorizontalAxis < 0)
            {
                horizontalAxis = 0;
            }
            if (HorizontalAxis == 0)
            {
                horizontalAxis = 1;
            }
            if (HorizontalAxis > 0)
            {
                horizontalAxis = 2;
            }

            if(Jump)
            {
                jump = 1;
            }

            return new byte[] { horizontalAxis, jump };
        }

    }
}
