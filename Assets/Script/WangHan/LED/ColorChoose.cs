using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using FFTAICommunicationLib;

public class ColorChoose : MonoBehaviour
{
    /// <summary> 灯光状态  /// </summary>
    public Button lightStatus;

    /// <summary> 按钮的父物体  /// </summary>
    public Transform buttonParent;

    /// <summary> 是否点击了灯光状态按钮  /// </summary>
    private bool isClickLightStatus;

    /// <summary> 选中的led按钮   /// </summary>
    public List<Control_LEDButton> ledList = new List<Control_LEDButton>();

    /// <summary> 每个按钮的目标点位置集合  /// </summary>
    private List<Vector3> destinationList = new List<Vector3>();

    /// <summary> 当前选中的灯的颜色/// </summary>
    public LEDColorStatus currentSelectedColor=LEDColorStatus.White;

    private void Awake()
    {
        for (int i = 0; i < ledList.Count; i++)
        {
            ledList[i].clickAction = ButtonClickEvent;
        }

        //绑定按钮的点击事件
        lightStatus.onClick.AddListener(() =>
        {
            OnClickLightStatus();
        });
    }

    private void Start()
    {
        SetToDestination();
    }

    /// <summary>
    /// 点击状态灯按钮的方法
    /// </summary>
    public void OnClickLightStatus()
    {
        if (!isClickLightStatus)
        {
            BackToOrigin();
            isClickLightStatus = true;
        }
        else
        {
            MoveToDestination();
            isClickLightStatus = false;
        }
    }

    /// <summary>
    /// 按钮移动到原点置的动画
    /// </summary>
    private void BackToOrigin()
    {
        DOTween.KillAll();
        for (int i = 0; i < ledList.Count; i++)
        {
            ledList[i].transform.DOLocalMove(Vector3.zero, 1f);
        }
        buttonParent.DOLocalRotate(new Vector3(0, 0, 0), 1f).OnComplete(()=> 
        {
            SetButtonStatus(false);
        });
    }

    /// <summary>
    ///  按钮移动到目标位置的动画
    /// </summary>
    private void MoveToDestination()
    {
        DOTween.KillAll();
        for (int i = 0; i < ledList.Count; i++)
        {
            ledList[i].transform.DOLocalMove(destinationList[i],1f);
        }
        buttonParent.DOLocalRotate(new Vector3(0, 0, 120), 1.4f).OnPlay(() =>
        {
            SetButtonStatus(true);
        });
    }

    /// <summary>
    /// 按钮在目的点位置
    /// </summary>
    private void SetToDestination()
    {
        for (int i = 0; i < ledList.Count; i++)
        {
            ledList[i].transform.localPosition =new Vector3(136f, 0, 0);
        }
        //设置每个按钮的旋转角度
        float angle = 360f / ledList.Count;
        for (int i = 0; i < ledList.Count; i++)
        {
            ledList[i].transform.RotateAround(buttonParent.position,Vector3.forward, angle * i);
            destinationList.Add(ledList[i].transform.localPosition) ;
        }
        buttonParent.Rotate(new Vector3(0, 0, 120));
    }

    private void ButtonClickEvent(LEDColorStatus ledColor,GameObject obj)
    {
        BackToOrigin();
        lightStatus.GetComponent<Image>().color = obj.GetComponent<Button>().colors.normalColor;  
        isClickLightStatus = true;
        currentSelectedColor = ledColor;
    }

    /// <summary>
    /// 设置按钮的激活状态
    /// </summary>
    /// <param name="isActive"></param>
    private void SetButtonStatus(bool isActive)
    {
        for (int i = 0; i < ledList.Count; i++)
        {
            ledList[i].gameObject.SetActive(isActive);
        }
    }
}
