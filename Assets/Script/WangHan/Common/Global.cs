using UnityEngine;
using System.Collections;
using System;

public abstract class Global
{
    /// <summary>
    /// 根据名字遍历组件
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="childName"></param>
    /// <returns></returns>
	public static Transform FindChild(Transform trans , string childName)
	{
		Transform child = trans.Find(childName);
		if (child != null)
		{
			return child;
		}
		int count = trans.childCount;
		Transform go = null;
		for(int i = 0 ; i < count ; ++i)
		{
			child = trans.GetChild(i);
			go = FindChild(child, childName);
			if (go != null)
				return go;
		}
		return null;
	}

    /// <summary>
    /// 根据指定类型来根据名字遍历组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="trans"></param>
    /// <param name="childName"></param>
    /// <returns></returns>
	public static T FindChild<T>(Transform trans, string childName) where T : Component
	{
		Transform go = FindChild(trans,childName);
		if(go == null)
			return null;
		return go.GetComponent<T>();
	}

    /// <summary>
    /// 删除父物体下所有子物体
    /// </summary>
    /// <param name="parentTran"></param>
    public static void DestroyChild(Transform parentTran)
    {
        for (int i = 0; i < parentTran.childCount; i++)
        {
            Transform childTran = parentTran.GetChild(i);
            GameObject.Destroy(childTran.gameObject);
        }
    }

    /// <summary>
    /// 获取桌面路径
    /// </summary>
    public static string GetDesktopPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    }
}
