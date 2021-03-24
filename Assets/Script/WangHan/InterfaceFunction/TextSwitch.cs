using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 该脚本的作用是，当按钮在禁用交互和激活交互时，改变字体的颜色
/// </summary>
public class TextSwitch : MonoBehaviour
{
    /// <summary>激活时的字体颜色// </summary>
    public Color activeColor;

    /// <summary>不激活时的字体颜色// </summary>
    public Color disableColor;

    /// <summary>需要改变颜色的字体/// </summary>
    private Text text;

    /// <summary>监控是否激活的按钮/// </summary>
    private Button button;
    private void Start()
    {
        button = transform.GetComponent<Button>();
        text=transform.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (button.IsInteractable())
        {
            text.color = activeColor;
        }
        else
        {
            text.color = disableColor;
        }
    }
}
