using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public class Debugs
    {
        public static Action<object,int> action;

        private static int status = FFTAIRobotCommLogStatus.ON;

        public static int Log(object info, int type= FFTAIRobotCommLogType.NORMAL)
        {
            if (action!=null)
            {
                action.Invoke(info, type);
            }

            if (status == FFTAIRobotCommLogStatus.OFF)
            {
                return FunctionResult.SUCCESS;
            }

            if (type == FFTAIRobotCommLogType.NORMAL)
            {
               // UnityEngine.Debug.Log(string.Format("<color=grey>{0}</color>", info));
            }
            else if (type == FFTAIRobotCommLogType.DEBUG)
            {
                //UnityEngine.Debug.Log(string.Format("<color=green>{0}</color>", info));
            }
            else if (type == FFTAIRobotCommLogType.WARNING)
            {
                //UnityEngine.Debug.Log(string.Format("<color=yellow>{0}</color>", info));
            }
            else if (type == FFTAIRobotCommLogType.ERROR)
            {
                //UnityEngine.Debug.Log(string.Format("<color=red>{0}</color>", info));
            }
            return FunctionResult.SUCCESS;
        }
    }

    public class FFTAIRobotCommLogStatus
    {
        public const int ON = 1;
        public const int OFF = 0;
    }

    public class FFTAIRobotCommLogType
    {
        public const int NORMAL = 0;
        public const int DEBUG = 1;
        public const int WARNING = 2;
        public const int ERROR = 3;
        public const int NONE = 4;
    }
}
