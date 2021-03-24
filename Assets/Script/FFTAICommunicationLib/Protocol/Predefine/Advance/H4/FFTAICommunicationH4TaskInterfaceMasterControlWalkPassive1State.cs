using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1State
    {
        // none
        public const int NONE     = 0x00;

        // basic
        public const int STOP = 0x010101;
        public const int PAUSE = 0x020101;
        public const int JOG = 0x030101;

        public const int TO_SIT = 0x040101;
        public const int TO_STAND = 0x040102;

        // calibrate
        public const int CALIBRATESIT = 0xA00101;
        public const int CALIBRATESIT_TO_CALIBRATESTAND = 0xA00102;

        public const int CALIBRATESTAND = 0xA00201;

        // walk
        public const int SIT = 0x100101;

        public const int SIT_TO_STAND = 0x110201;

        public const int STAND = 0x200101;

        public const int STAND_TO_SIT = 0x210201;
        public const int STAND_TO_WALK = 0x210202;

        public const int WALK = 0x300101;
    }
}
