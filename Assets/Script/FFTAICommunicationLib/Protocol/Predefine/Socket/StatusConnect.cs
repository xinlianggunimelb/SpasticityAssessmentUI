using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class StatusConnect
    {
        public const int  NONE = 0x00000000;

        public const int  CONNECTED = 0x01;
        public const int  DISCONNECTED = 0x02;
        public const int  CONNECTING = 0x03;
        public const int  DISCONNECTING = 0x04;
    }
}
