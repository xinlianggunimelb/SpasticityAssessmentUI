using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationFunctionType
    {
        //public const int  NONE = 0x00;

        //public const int  IAP_INTERFACE = 0x7AAAAAAA;

        //public const int  COMMUNICATION_INTERFACE = 0x7FFFFFFF;

        //public const int  APP_INTERFACE = 0x01010101;
        //public const int  HARDWARE_INTERFACE = 0x01010201;
        //public const int  DRIVER_INTERFACE = 0x01010301;
        //public const int  MOTOR_INTERFACE = 0x01010401;
        //public const int  ROBOT_INTERFACE = 0x01010501;

        //public const int  H4_ROBOT_INTERFACE = 0x48340101;
        //public const int  H4_TASK_INTERFACE = 0x48340103;

        //public const int  M1_ROBOT_INTERFACE = 0x4D310101;
        //public const int  M1_TASK_INTERFACE = 0x4D310103;

        //public const int M1_L_ROBOT_INTERFACE = 0x4D317501;
        //public const int M1_L_TASK_INTERFACE = 0x4D317503;

        //public const int  M2_ROBOT_INTERFACE = 0x4D320101;
        //public const int  M2_TASK_INTERFACE = 0x4D320103;

        //public const int  M3_ROBOT_INTERFACE = 0x4D330101;
        //public const int  M3_TASK_INTERFACE = 0x4D330103;

        //public const int M6_ROBOT_INTERFACE = 0x4D360101;
        //public const int M6_TASK_INTERFACE = 0x4D360103;

        //public const int  X1_ROBOT_INTERFACE = 0x58310101;
        //public const int  X1_TASK_INTERFACE = 0x58310103;

        //public const int  X2_ROBOT_INTERFACE = 0x58320101;
        //public const int  X2_TASK_INTERFACE = 0x58320103;

        public const int NONE = 0x00;

        public static int IAP_INTERFACE
        {
            get 
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x7AAAAAAA;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x01010101;
                }
                else
                {
                    // if not v2 or v3 return the header of v2
                    return 0x7AAAAAAA;
                }
            }
           
        }

        public static int COMMUNICATION_INTERFACE
        {
            get
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x7FFFFFFF;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x00000001;
                }
                else
                {
                    // if not v2 or v3 return the header of v2
                    return 0x7FFFFFFF;
                }
            }
        }

        public static int APP_INTERFACE 
        {
            get 
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x01010101;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x10010101;
                }
                else
                {
                    // if not v2 or v3 return the header of v2
                    return 0x01010101;
                }
            }
        }

        public static int HARDWARE_INTERFACE
        {
            get
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x01010201;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x10010201;
                }
                else
                {
                    // if not v2 or v3 return the header of v2
                    return 0x01010201;
                }
            }
        } 
        public static int DRIVER_INTERFACE
        {
            get
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x01010301;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x10010301;
                }
                else
                {
                    // if not v2 or v3 return the header of v2
                    return 0x01010301;
                }
            }
        }
        public static int MOTOR_INTERFACE 
        {
            get
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x01010401;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x10010401;
                }
                else
                {
                    // if not v2 or v3 return the header of v2
                    return 0x01010401;
                }
            }
        }
        public static int ROBOT_INTERFACE 
        {
            get
            {
                //if protocol v2
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x01010501;
                }
                //if protocol v3
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x10010501;
                }
                else
                {
                    // if not v2 or v3 return the header of v2
                    return 0x01010501;
                }
            }
        }

        public const int TASK_INTERFACE = 0x10010601;

        public const int H4_ROBOT_INTERFACE = 0x48340101;
        public const int H4_TASK_INTERFACE = 0x48340103;

        public const int M1_ROBOT_INTERFACE = 0x4D310101;
        public const int M1_TASK_INTERFACE = 0x4D310103;

        public const int M1_L_ROBOT_INTERFACE = 0x4D317501;
        public const int M1_L_TASK_INTERFACE = 0x4D317503;

        public const int M2_ROBOT_INTERFACE = 0x4D320101;
        public const int M2_TASK_INTERFACE = 0x4D320103;

        public const int M3_ROBOT_INTERFACE = 0x4D330101;
        public const int M3_TASK_INTERFACE = 0x4D330103;

        public const int M6_ROBOT_INTERFACE = 0x4D360101;
        public const int M6_TASK_INTERFACE = 0x4D360103;

        public const int X1_ROBOT_INTERFACE = 0x58310101;
        public const int X1_TASK_INTERFACE = 0x58310103;

        public const int X2_ROBOT_INTERFACE = 0x58320101;
        public const int X2_TASK_INTERFACE = 0x58320103;


    }
}
