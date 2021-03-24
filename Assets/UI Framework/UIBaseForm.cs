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
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum FormShowType { Normal = 0,Popup = 1}
public abstract class UIBaseForm: MonoBehaviour 
{
    /// <summary>面板类型 /// </summary>
    public FormShowType showType = FormShowType.Normal;

    /// <summary>开始的时候是否隐藏面板/// </summary>
    public bool closeOnStart = true;
    
    /// <summary>开始的时候是否设置面板到本地坐标为零的位置/// </summary>
    public bool setPositionZero = false;

    /// <summary>面板名称 /// </summary>
    public string UIName;

    /// <summary>该标题主要是用于本人在Scene场景中做标识，所以在程序启动的时候需要将这些标识隐藏/// </summary>
    [HideInInspector]
    public GameObject titleObj;
    
    protected void Awake()
    {
        AwakeInit();
        UIManager.Instance.RegisterUI(UIName, this);
        if (setPositionZero)
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }

    public virtual void Start()
    {
        //隐藏标题
        if (titleObj)
        {
            titleObj.SetActive(false);
        }
    }

    protected virtual void AwakeInit()
    {
        UIName = gameObject.name;
        //获取面板的标识
        Transform titleTran = Global.FindChild(transform, "标识");
        if (titleTran)
        {
            titleObj = titleTran.gameObject;
        }
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    public void Show()
    {
        Display();
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    public void Hide()
    {
        Close();
    }

    /// <summary>
    /// 显示面板，供子类重写
    /// </summary>
    protected virtual void Display()
    {
        switch (showType)
        {
            case FormShowType.Popup:
                transform.SetAsLastSibling();
                break;
            default:
                break;
        }
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 隐藏面板，供子类重写
    /// </summary>
    protected virtual void Close()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 激活指定场景内的所有物体
    /// </summary>
    public void ActiveAllObj(Scene scene)
    {
        GameObject[] objs = scene.GetRootGameObjects();
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(true);
        }
    }
    
    /// <summary>
    /// 隐藏场景内的所有物体
    /// </summary>
    public void HideAllObj(Scene scene)
    {
        GameObject[] objs = scene.GetRootGameObjects();
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(false);
        }
    }

    private void OnDestroy()
    {
        //UIManager.Instance.UnRegisterUI(UIName);
    }
}
