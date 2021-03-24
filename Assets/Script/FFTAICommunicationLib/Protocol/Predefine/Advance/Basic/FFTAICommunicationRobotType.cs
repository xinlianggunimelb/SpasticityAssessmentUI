using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationRobotType
    {
        public const int NONE = 0x00000000;

        public const int H1 = 0x48310000;
        public const int H4 = 0x48340000;

        public const int M1 = 0x4D310000;
        public const int M1_L = 0x4D311675;
        public const int M2 = 0x4D320000;
        public const int M3 = 0x4D330000;
        public const int M6 = 0x4D360000;

        public const int X1 = 0x58310000;
        public const int X2 = 0x58320000;

        public const int All = 0x7FFFFFFF;
    }
}
