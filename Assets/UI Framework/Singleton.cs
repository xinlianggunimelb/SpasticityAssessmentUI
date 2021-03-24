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

/// <summary>
/// 单例模式
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType(typeof(T)) as T;
                if (_Instance==null)
                {
                    _Instance = new GameObject("Singleton of " + typeof(T).ToString(), typeof(T)).GetComponent<T>();
                }
            }
            return _Instance;
        }
    }
    protected static T _Instance;

    protected virtual void Awake()
    {
        _Instance = gameObject.GetComponent<T>();
    }
}
