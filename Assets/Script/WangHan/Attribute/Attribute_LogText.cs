using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 输出类容的属性
/// </summary>
public class Attribute_LogText : MonoBehaviour
{
    /// <summary>输出的类型 正常/警告/错误 /// </summary>
    public int type;

    /// <summary>输出的时间 /// </summary>
    public Text time;

    /// <summary>输出的文字内容 /// </summary>
    public Text info;
}


