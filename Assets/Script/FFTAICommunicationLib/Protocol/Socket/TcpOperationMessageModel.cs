using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class TcpOperationMessageModel
    {
        public byte[] message = new byte[200];
        public int  messageLength = 0;
    }
}
