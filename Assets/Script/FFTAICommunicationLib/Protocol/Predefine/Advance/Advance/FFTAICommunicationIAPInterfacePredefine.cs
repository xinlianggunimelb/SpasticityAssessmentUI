using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationIAPInterfacePredefine
    {
        //v2  通信定义字段数值
        //public const int NONE = 0x00000000;

        //public const int INITED_FLAG = 0x0F010101;
        //public const int SOFTWARE_VERSION = 0x0F010201;

        //public const int BOOT_MODE = 0x01010101;
        //public const int WORK_STATUS = 0x01010102;

        //public const int IAP_START_ADDRESS = 0x01010201;
        //public const int IAP_SIZE = 0x01010202;

        //public const int APP_START_ADDRESS = 0x01010301;
        //public const int APP_SIZE = 0x01010302;

        //public const int UPGRADE_IAP = 0x02010101;
        //public const int UPGRADE_IAP_FAST = 0x02010102;
        //public const int UPGRADE_IAP_MIDDLE = 0x02010103;
        //public const int UPGRADE_IAP_SLOW = 0x02010104;

        //public const int UPGRADE_APP = 0x03010101;
        //public const int UPGRADE_APP_FAST = 0x03010102;
        //public const int UPGRADE_APP_MIDDLE = 0x03010103;
        //public const int UPGRADE_APP_SLOW = 0x03010104;

        //public const int ERASE_IAP = 0x04010101;
        //public const int ERASE_APP = 0x04010102;

        //public const int UPGRADE_IAP_FAST_AMOUNT = 100;
        //public const int UPGRADE_IAP_MIDDLE_AMOUNT = 20;
        //public const int UPGRADE_IAP_SLOW_AMOUNT = 1;

        //public const int UPGRADE_APP_FAST_AMOUNT = 100;
        //public const int UPGRADE_APP_MIDDLE_AMOUNT = 20;
        //public const int UPGRADE_APP_SLOW_AMOUNT = 1;

        public const int NONE = 0x00000000;

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
                    return 0x10010101;
                }
                else
                {
                    return 0x0F010101;
                }
            }
        }
        public const int HARDWARE_VERSION = 0x10010201;
        public static int SOFTWARE_VERSION
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x0F010201;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x10010202;
                }
                else
                {
                    return 0x0F010201;
                }
            }
        }


        public const int BOOT_MODE = 0x01010101;
        public const int WORK_STATUS = 0x01010102;
        public const int IAPModel_EXIST_FLAG = 0x01010103;
        public const int APP_EXIST_FLAG = 0x01010104;


        public const int IAP_START_ADDRESS = 0x01010201;
        public const int IAP_SIZE = 0x01010202;
        public const int IAP_END_ADDRESS = 0x01010103;

        public const int APP_START_ADDRESS = 0x01010301;
        public const int APP_SIZE = 0x01010302;
        public const int APP_END_ADDRESS = 0x01010303;

        public const int UPGRADE_IAP = 0x02010101;
        public const int UPGRADE_IAP_FAST = 0x02010102;
        public const int UPGRADE_IAP_MIDDLE = 0x02010103;
        public static int UPGRADE_IAP_SLOW
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x02010104;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x02010101;
                }
                else
                {
                    return 0x02010104;
                }
            }
        }

        public const int UPGRADE_APP = 0x03010101;
        public const int UPGRADE_APP_FAST = 0x03010102;
        public const int UPGRADE_APP_MIDDLE = 0x03010103;
        public static int UPGRADE_APP_SLOW
        {
            get
            {
                if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_2)
                {
                    return 0x03010104;
                }
                else if (FFTAICommunicationInterfaceModel.FFTAICommunicationProtocolVersion == FFTAICommunicationProtocolVersion.VERSION_3)
                {
                    return 0x03010101;
                }
                else
                {
                    return 0x03010104;
                }
            }
        }

        public const int ERASE_IAP = 0x04010101;
        public const int ERASE_APP = 0x04010102;

        public const int UPGRADE_IAP_FAST_AMOUNT = 100;
        public const int UPGRADE_IAP_MIDDLE_AMOUNT = 20;
        public const int UPGRADE_IAP_SLOW_AMOUNT = 1;

        public const int UPGRADE_APP_FAST_AMOUNT = 100;
        public const int UPGRADE_APP_MIDDLE_AMOUNT = 20;
        public const int UPGRADE_APP_SLOW_AMOUNT = 1;
    };
}
