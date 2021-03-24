using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationHardwareInterfacePredefine
    {
        public const int  NONE = 0x00000000;

        // Gpio Model
        public const int  GPIO_OUTPUT_STATUS = 0x01010101;
        public const int  GPIO_INTPUT_STATUS = 0x01010102;

        public const int  GPIO_RED_LED_STATUS = 0x01020101;
        public const int  GPIO_YELLOW_LED_STATUS = 0x01020102;
        public const int  GPIO_BLUE_LED_STATUS = 0x01020103;

        // Can Model
        public const int  SEND_CAN_MESSAGE = 0x02010101;
        public const int  RECEIVE_CAN_MESSAGE = 0x02010102;
        public const int  SEND_CANOPEN_MESSAGE = 0x02010103;

    };
}
