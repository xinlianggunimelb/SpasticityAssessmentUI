using FFTAICommunicationLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{

    float time;

    public DynaLinkHS.RobotType robotType;
    private void Update()
    {
        //time += Time.deltaTime;
        //if (time>1)
        //{
        //    time = 0;
        //    FFTAIRobotCommLog.getInstance().WriteLine("测试", FFTAIRobotCommLogType.DEBUG);
        //}
        DynaLinkHS.StatusFlag.FlagServerLinkActive = 0x01;
        DynaLinkHS.StatusApp.RobotType = robotType;
    }
}
