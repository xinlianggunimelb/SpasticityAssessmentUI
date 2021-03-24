using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationAPPInterfacePredefine
    {
        //public const int  NONE = 0x00000000;

        //public const int  INITED_FLAG = 0x0F010101;

        //public const int  HARDWARE_VERSION = 0x01010101;
        //public const int  SOFTWARE_VERSION = 0x01010102;

        //public const int  SERIAL_NUMBER = 0x01010201;

        //public const int  RUN_TIME_COUNT = 0x0A010101;
        //public const int  ETHERNET_TYPE = 0x0A010103;
        //public const int  ETHERNET_TCP_FRAMEWORK_TYPE = 0x0A010104;
        //public const int  ETHERNET_UDP_FRAMEWORK_TYPE = 0x0A010105;
        //public const int  ROBOT_TYPE = 0x0A010106;
        //public const int  MECHANISM_VERSION = 0x0A010107;
        //public const int  COMMUNICATION_PROTOCOL_VERSION = 0x0A010108;
        //public const int  ROBOT_SERIAL_NUMBER = 0x0A010109;

        public static int NONE = 0x00000000;
               
        public static int INITED_FLAG
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0F010101;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x10000101;
                }
                else
                {
                    return 0x0F010101;
                }
            }
        }
              
        public static int HARDWARE_VERSION 
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x01010101;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x10010101;
                }
                else
                {
                    return 0x01010101;
                }
            }
        }
        public static int SOFTWARE_VERSION
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x01010102;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x10010102;
                }
                else
                {
                    return 0x01010102;
                }
            }
        } 
               
        public static int SERIAL_NUMBER
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x01010201;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010101;
                }
                else
                {
                    return 0x01010201;
                }
            }
        }
               
        public static int RUN_TIME_COUNT
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0A010101;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010102;
                }
                else
                {
                    return 0x0A010101;
                }
            }
        }

        public static int ETHERNET_TYPE
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0A010103;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010103;
                }
                else
                {
                    return 0x0A010103;
                }
            }
        }
        public static int ETHERNET_TCP_FRAMEWORK_TYPE
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0A010104;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010104;
                }
                else
                {
                    return 0x0A010104;
                }
            }
        }

        public static int ETHERNET_UDP_FRAMEWORK_TYPE
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0A010105;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010105;
                }
                else
                {
                    return 0x0A010105;
                }
            }
        }

        public static int ROBOT_TYPE
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0A010106;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010106;
                }
                else
                {
                    return 0x0A010106;
                }
            }
        }

        public static int MECHANISM_VERSION
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0A010107;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010107;
                }
                else
                {
                    return 0x0A010107;
                }
            }
        }

        public static int COMMUNICATION_PROTOCOL_VERSION
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0A010108;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010108;
                }
                else
                {
                    return 0x0A010108;
                }
            }
        }

        public static int ROBOT_SERIAL_NUMBER
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0A010109;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010109;
                }
                else
                {
                    return 0x0A010109;
                }
            }
        }

        //Editor IP  Adress
        public const int EthernetAddressTcpPart4Set = 0x24010101;
    };
}
