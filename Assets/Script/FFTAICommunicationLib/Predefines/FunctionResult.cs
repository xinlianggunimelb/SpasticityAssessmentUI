using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class FunctionResult
    {
        public const int  NONE = 0xFF;
        public const int  SUCCESS = 0;
        public const int  FAIL = -1;
        public const int  NO_DATA = -2;
        public const int  OBJECT_DISPOSE_EXCEPTION = -2;
        public const int  ARGUMENT_EXCEPTION = -2;
        public const int  ARGUMENT_NULL_EXCEPTION = -2;
        public const int  ARGUMENT_OUT_OF_RANGE_EXCEPTION = -2;
        public const int  FORMAT_EXCEPTION = -2;
        public const int  SOCKET_EXCEPTION = -2;
        public const int  SECURITY_EXCEPTION = -2;
        public const int  INVALID_OPERATION_EXCEPTION = -2;
        public const int  PLATFORM_NOT_SUPPORT_EXCEPTION = -2;
        public const int  NETWORK_ALREADY_CONNECTED = -2;
        public const int  NETWORK_ALREADY_DISCONNECTED = -2;
    }
}
