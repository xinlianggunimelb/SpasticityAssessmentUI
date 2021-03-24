using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationProtocolVersion
    {
        public const int  NONE = 0x00000000;

        public static int  VERSION_1 = 0x00000001;
        public static int  VERSION_2= 0x00000002;
        public static int  VERSION_3 = 0x00000003;

        public static int CurrentVersion
        {
            get
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion ==VERSION_2)
                {
                    return VERSION_2;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion ==VERSION_3)
                {
                    return VERSION_3;
                }
                else
                {
                    return VERSION_2;
                }
            }
            set
            {
                FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion = value;
            }
        }
    }
}
