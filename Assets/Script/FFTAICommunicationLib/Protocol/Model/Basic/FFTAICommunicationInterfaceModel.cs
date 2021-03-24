using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationInterfaceModel
    {
        public static int FFTAICommunicationProtocolVersion= 0x00000002;

        public byte[] ReceiveMessageBuf = new byte[2048];
        public int  ReceiveMessageBufLength = 0;

		public byte[] SendMessageBuf = new byte[2048];
        public int  SendMessageBufLength = 0;

        // model initilization
        public FFTAICommunicationInterfaceModel()
        {

        }
    
    }

}
