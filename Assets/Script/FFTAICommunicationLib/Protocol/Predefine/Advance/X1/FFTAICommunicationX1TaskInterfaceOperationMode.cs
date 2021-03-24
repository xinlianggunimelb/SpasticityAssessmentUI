using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationX1TaskInterfaceOperationMode
    {
        // Basic
        public const int BasicWorkMode = 0x01010101;

        public const int BasicFlagTaskInProcess = 0x01010201;

        // Debug
        public const int DebugSetWorkMode = 0x01010101;

        // Relay
        public const int RelayControlSetWorkMode = 0x02010101;

        // Master Control
        public const int MasterControlSetWorkMode = 0x03010101;

       public const int MasterControlSetWalkPassive1Command = 0x03110101;
       public const int MasterControlSetWalkPassive2Command = 0x03120101;
       public const int MasterControlSetWalkPassive3Command = 0x03130101;
       public const int MasterControlSetWalkPassive4Command = 0x03140101;

       public const int MasterControlSetSitStandTrainingCommand = 0x03210101;

    };

    public class FFTAICommunicationX1TaskInterfaceWorkMode
    {
        public const int Debug = 0x01;
        public const int Relay = 0x02;
        public const int MasterControl = 0x03;
    };

    public class FFTAICommunicationX1TaskInterfaceMasterControlWorkMode
    {
        public const int None = 0x00;
        public const int WalkPassive1 = 0x11;
    }

    public class FFTAICommunicationX1TaskInterfaceMasterControlWalkPassive1Command
    {
        public const int SetHome = 0x10;
        public const int Stop = 0x01;
        public const int Sit = 0x02;
        public const int Stand = 0x03;
        public const int Walk = 0x04;
    }
}
