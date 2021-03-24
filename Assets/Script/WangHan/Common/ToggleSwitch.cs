using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 工具类脚本，用于切换按钮，可以实现多种切换（图片，文字，颜色等的切换）
/// </summary>
public class ToggleSwitch : MonoBehaviour
{
    /// <summary>开关打开时的字体颜色/// </summary>
    public Color toggleOnColor;

    /// <summary>开关关闭时的字体颜色/// </summary>
    public Color toggleOffColor;

    /// <summary>背景/// </summary>
    public Image background;

    /// <summary>选中/// </summary>
    public Image check;

    /// <summary>开关/// </summary>
    private Toggle toggle;

    /// <summary>文字/// </summary>
    private Text label;

    public void Awake()
    {
        toggle = transform.GetComponent<Toggle>();
        label = transform.GetComponentInChildren<Text>();
    }

    public void Start()
    {
        if (toggle.isOn)
        {
            ToggleOn();
        }
        else
        {
            ToggleOff();
        }

        toggle.onValueChanged.AddListener((a) => 
        {
            if (a)
            {
                ToggleOn();
            }
            else
            {
                ToggleOff();
            }
        });
    }

    /// <summary>
    /// 当开关打开时的按钮状态
    /// </summary>
    private void ToggleOn()
    {
        label.color = toggleOnColor;
        background.gameObject.SetActive(false);
        check.gameObject.SetActive(true);
    }

    /// <summary>
    /// 当开关关闭时的按钮状态
    /// </summary>
    private void ToggleOff()
    {
        label.color = toggleOffColor;
        background.gameObject.SetActive(true);
        check.gameObject.SetActive(false);
    }
}
