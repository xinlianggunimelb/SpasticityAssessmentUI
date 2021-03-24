using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_Network : MonoBehaviour
{
    /// <summary> unity自带的ping工具/// </summary>
    private Ping ping;

    /// <summary> ping过程是否已经结束了 /// </summary>
    private bool isPingDone;

    private void Start()
    {
        StartCoroutine(RepeatFunction());
    }

    /// <summary>
    /// 重复执行检测网络联通的方法
    /// </summary>
    /// <returns></returns>
    IEnumerator RepeatFunction()
    {
        while(true)
        {
            StartCoroutine(PingTimeOut());
            yield return new WaitUntil(()=>isPingDone==true);
            isPingDone = false;
            yield return new WaitForSeconds(1f);
        }
    }

    /// <summary>
    /// 检测ping是否超时
    /// </summary>
    /// <returns></returns>
    private IEnumerator PingTimeOut()
    {
        ping = new Ping(Parameter_Main.targetIPAddress);
        int nTime = 0;
        while (!ping.isDone)
        {
            yield return null;
            if (nTime>20)
            {
                Parameter_Main.isNetConnect = false;
                isPingDone = true;
                yield break;
            }
            nTime++;
        }
        Parameter_Main.isNetConnect = true;
        isPingDone = true;
    }
}
