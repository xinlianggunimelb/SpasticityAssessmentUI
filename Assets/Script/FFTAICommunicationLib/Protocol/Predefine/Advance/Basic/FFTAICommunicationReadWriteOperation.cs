using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FFTAICommunicationReadWriteOperation
    {
        //READ = 0x10; 
        //WRITE = 0x11;
        //GET = 0x00;  
        //SET = 0x01;  

        public const int NONE = 0;
        public const int READ = 1; ///< read operation, with flash
        public const int WRITE = 2; ///< write operation, with flash
        public const int GET = 3; ///< get operation, not with flash
        public const int SET = 4; ///< set operation, not with flash
    }
}
