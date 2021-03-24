using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationFillingParameter
    {
        public static int PATCH
        {
            get 
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion== FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return ZERO;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return INT;
                }
                else
                {
                    return NONE;
                }
            }
        }
        public const int ZERO= 0x00000000;
        public const int NONE = 0x00000000;
        public const int CHAR = 0x00000001;
        public const int SHORT = 0x00000002;
        public const int INT = 0x00000004;
        public const int FLOAT = 0x00000010;
    }
}
