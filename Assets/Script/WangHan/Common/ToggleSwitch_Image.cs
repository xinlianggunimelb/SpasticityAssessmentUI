using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 工具类脚本，用于切换按钮，可以实现图片的切换
/// </summary>
public class ToggleSwitch_Image : MonoBehaviour
{
    /// <summary>背景/// </summary>
    public Image background;

    /// <summary>选中/// </summary>
    public Image check;

    /// <summary>开关/// </summary>
    private Toggle toggle;

    public void Awake()
    {
        toggle = transform.GetComponent<Toggle>();
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
        background.gameObject.SetActive(false);
        check.gameObject.SetActive(true);
    }

    /// <summary>
    /// 当开关关闭时的按钮状态
    /// </summary>
    private void ToggleOff()
    {
        background.gameObject.SetActive(true);
        check.gameObject.SetActive(false);
    }
}
