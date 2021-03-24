﻿/***************************************************************
文件名：loom.cs
作者：师国超    版本：Version 1.0
版权：©2014-2019 上海形拓科技有限公司 版权所有
功能描述：主线程子线程交互
创建时间：2019.4.15
---------------------------------------------------------------
1.
修改时间：
修改者：
修改内容：
---------------------------------------------------------------
***************************************************************/


using System;
using System.Collections.Generic;
using System.Threading;  
using System.Linq;
using UnityEngine;

public class Loom : MonoBehaviour  
{  
    public static int maxThreads = 8;  
    static int numThreads;

    private static Loom _current;
    public static Loom Current  
    {  
        get  
        {  
            Initialize();  
            return _current;  
        }  
    }  

    static bool initialized;  

    //####作为初始化方法自己调用，可在初始化场景调用一次即可
    public static void Initialize()  
    {  
        if (!initialized)  
        {  

            if(!Application.isPlaying)  
                return;  
            initialized = true;  
            GameObject g = new GameObject("Loom");  
            //####永不销毁
            DontDestroyOnLoad (g);
            _current = g.AddComponent<Loom>();  
        }  

    }  

    private List<Action> _actions = new List<Action>();  
    public struct DelayedQueueItem  
    {  
        public float time;  
        public Action action;  
    }  
    private List<DelayedQueueItem> _delayed = new  List<DelayedQueueItem>();  

    List<DelayedQueueItem> _currentDelayed = new List<DelayedQueueItem>();  

    public static void QueueOnMainThread(Action action)  
    {  
        QueueOnMainThread( action, 0f);  
    }  
    public static void QueueOnMainThread(Action action, float time)  
    {  
        if(time != 0)  
        {
            if (Current != null)
            {
                lock (Current._delayed)
                {
                    Current._delayed.Add(new DelayedQueueItem { time = Time.time + time, action = action });
                }
            }
        }  
        else  
        {
            if (Current != null)
            {
                lock (Current._actions)
                {
                    Current._actions.Add(action);
                }
            }
        }  
    }  

    public static Thread RunAsync(Action a)  
    {  
        Initialize();  
        while(numThreads >= maxThreads)  
        {  
            Thread.Sleep(1);  
        }  
        Interlocked.Increment(ref numThreads);  
        ThreadPool.QueueUserWorkItem(RunAction, a);  
        return null;  
    }  

    private static void RunAction(object action)  
    {  
        try  
        {  
            ((Action)action)();  
        }  
        catch  
        {  
        }  
        finally  
        {  
            Interlocked.Decrement(ref numThreads);  
        }  

    }  


    void OnDisable()  
    {  
        if (_current == this)  
        {  

            _current = null;  
        }  
    }  



    // Use this for initialization  
    void Start()  
    {  

    }  

    List<Action> _currentActions = new List<Action>();  

    // Update is called once per frame  
    void Update()  
    {  
        lock (_actions)  
        {  
            _currentActions.Clear();  
            _currentActions.AddRange(_actions);  
            _actions.Clear();  
        }  
        foreach(var a in _currentActions)  
        {  
            a();  
        }  
        lock(_delayed)  
        {  
            _currentDelayed.Clear();
            for (int i = 0; i < _delayed.Count; i++)
            {
                if (_delayed[i].time <= Time.time)
                {
                    if (!_currentDelayed.Contains(_delayed[i]))
                    {
                        _currentDelayed.Add(_delayed[i]);
                    }
                }
            }
//            _currentDelayed.AddRange(_delayed.Where(d=>d.time <= Time.time));  
            foreach(var item in _currentDelayed)  
                _delayed.Remove(item);  
        }  
        foreach(var delayed in _currentDelayed)  
        {  
            delayed.action();  
        }  
    }  
}  
