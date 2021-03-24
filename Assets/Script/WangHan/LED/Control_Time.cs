using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_Time : MonoBehaviour
{
    /// <summary>  呼吸灯的间隔时间 /// </summary>
    public Text text;

    /// <summary>  按钮的点击事件 /// </summary>
    public ImageEvent imageEvent;

    /// <summary>  填充的背景 /// </summary>
    public Image filling;

    /// <summary>  时间 /// </summary>
    [HideInInspector]
    public float intervalTime=1;

    /// <summary>  填充的速度 /// </summary>
    public float speed=0.5f;

    private void Start()
    {
        filling.fillAmount = 1f / 6f;
        imageEvent.pointerClickAction = OnPointClickButton;
        imageEvent.pointerRightClickAction = OnPointRightClickButton;
        text.text = intervalTime.ToString();
    }

    private void OnPointClickButton()
    {
        filling.fillAmount += speed * Time.deltaTime;
        intervalTime = Mathf.Clamp(filling.fillAmount * 6,1,6);
        text.text = intervalTime.ToString("0.00");
    }

    private void OnPointRightClickButton()
    {
        float fillingAmount = filling.fillAmount;
        fillingAmount -= speed * Time.deltaTime;
        fillingAmount = Mathf.Clamp(fillingAmount, 1f / 6f, 1);
        filling.fillAmount = fillingAmount;
        intervalTime = Mathf.Clamp(filling.fillAmount * 6, 1, 6);
        text.text = intervalTime.ToString("0.00");
    }
}
