using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
/// <summary>
/// 创建一个资源工厂类,专门用来加载Resources里面的资源
/// </summary>
public static class ResourcesFactory
{
    private static Dictionary<string, GameObject> dicRes = new Dictionary<string, GameObject>();

    /// <summary>
    /// 加载资源
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <returns></returns>
    public static GameObject LoadResources(string path)
    {
        if(!dicRes.ContainsKey(path))
        {
            GameObject obj = Resources.Load<GameObject>(path);
            dicRes.Add(path, obj);
        }
        return dicRes[path];
    }
}

public class LoadToggle : MonoBehaviour
{
    /// <summary>
    /// 给加载出来的预制件添加文字
    /// </summary>
    /// <param name="obj">需要赋值的预制件</param>
    /// <param name="targetName">需要操作的组件名</param>
    /// <param name="text">需要操作的内容</param>
    /// <returns></returns>
   public static GameObject Load(GameObject obj,string targetName,string text)
    {
     GameObject target;
     if (targetName==null)
     {
         target = obj;
     }
     else
     target=Global.FindChild(obj.GetComponent<RectTransform>(), targetName).gameObject;
     target.GetComponent<Text>().text += text;
     return obj;
    }

    /// <summary>
    /// 给加载出来的预制件添加开关组标识
    /// </summary>
    /// <param name="obj">需要操作的预制件</param>
    /// <param name="targetName">需要操作的组件名</param>
    /// <param name="targetTra">需要操作的内容</param>
    /// <returns></returns>
    public static GameObject Load(GameObject obj,string targetName,Transform targetTra)
    {
        GameObject target;
        if (targetName == null)
        {
            target = obj;
        }
        else
            target = Global.FindChild(obj.GetComponent<RectTransform>(), targetName).gameObject;
        target.GetComponent<Toggle>().group = targetTra.GetComponent<ToggleGroup>();
        return obj;
    }
}



