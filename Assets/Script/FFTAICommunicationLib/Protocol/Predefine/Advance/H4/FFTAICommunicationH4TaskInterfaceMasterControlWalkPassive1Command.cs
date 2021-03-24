using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationH4TaskInterfaceMasterControlWalkPassive1Command
    {
        // none
        public const int NONE = 0x00;
        
        // calibration
        public const int CALIBRATION = 0xA0;

        // stop, pause, jog, move
        public const int STOP = 0x01;
        public const int PAUSE = 0x02;
        public const int JOG = 0x03;
        public const int MOVE = 0x04;

        // sit 
        public const int SIT_READY = 0x10;
        public const int SIT = 0x11;

        // stand
        public const int STAND_READY = 0x20;
        public const int STAND = 0x21;

        // walk
        public const int WALK_READY = 0x30;
        public const int WALK = 0x31;
    }
}
