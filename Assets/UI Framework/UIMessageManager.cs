/*************************************************
Simtop
Author: 刘全
Description: 
Others:
Function List: 
1. ....
History: 
// 者及修改内 容简述
1. Date:
Author:
Modification:
2. ...
*************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIMessageManager : Singleton<UIMessageManager> {
    public Dictionary<string, Action<object>> functions = new Dictionary<string, Action<object>>();

    /// <summary>
    /// 注册一个消息
    /// </summary>
    /// <param name="id">消息的名称，最好使用UIMessageNames的常量</param>
    /// <param name="function">执行的方法</param>
    public void RegisterMessage(string id, Action<object> function)
    {
        functions.Add(id, function);
    }

    /// <summary>
    /// 执行一个消息
    /// </summary>
    /// <param name="id">消息的名称，最好使用UIMessageNames的常量</param>
    /// <param name="param">方法的参数</param>
    public void ExecuteMessage(string id, object param)
    {
        if(functions.ContainsKey(id))
        functions[id](param);
    }
}
