using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static FFTAICommunicationLib.DynaLinkHS;

public class Control_LEDButton : MonoBehaviour
{
    /// <summary> Led灯的颜色 /// </summary>
    public LEDColorStatus ledStatus;

    /// <summary> led灯的按钮    /// </summary>
    private Button ledButton;

    /// <summary> 点击按钮后的回调事件   /// </summary>
    public Action<LEDColorStatus,GameObject> clickAction;

    private void Start()
    {
        ledButton = transform.GetComponent<Button>();
        ledButton.onClick.AddListener(() =>
        {
            if (clickAction != null)
            {
                clickAction.Invoke(ledStatus,gameObject);
                ledButton.transform.SetAsLastSibling();
            }
        });
    }
}

public enum LEDColorStatus:uint
{
    Off = LEDColor.Off,
    White = LEDColor.White,
    Cyan = LEDColor.Cyan,
    Yellow = LEDColor.Yellow,
    Magenta = LEDColor.Magenta,
    Red = LEDColor.Red,
    Green = LEDColor.Green,
    Blue = LEDColor.Blue,
    Colorful=0x09,
}


