using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{


    private Dictionary<string, Action<ArrayList>> eventDictionary;

    private static EventManager eventManager;
    //单例
    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                //在Unity的Hierarchy中必须有一个名为EventManager的空物体,并挂上EventManager脚本
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.Log("项目中没有EventManager，自动创建");
                    GameObject mangager = new GameObject("EventManager");
                    eventManager = mangager.AddComponent<EventManager>();
                    eventManager.Init();
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    public void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, Action<ArrayList>>();
        }
    }
    //在需要监听某个事件的脚本中，调用这个方法来监听这个事件
    public static void StartListening(string eventName, Action<ArrayList> action)
    {
        if (instance.eventDictionary.ContainsKey(eventName))
        {
            instance.eventDictionary[eventName] = action;
        }
        else
        {
            instance.eventDictionary.Add(eventName, action);
        }
    }
    //在不需要监听的时候停止监听
    public static void StopListening(string eventName)
    {
        if (instance.eventDictionary.ContainsKey(eventName))
        {
            instance.eventDictionary.Remove(eventName);
        }
    }
    //触发某个事件
    public static void TriggerEvent(string eventName, ArrayList obj)
    {
        if (instance.eventDictionary.ContainsKey(eventName))
        {
            instance.eventDictionary[eventName].Invoke(obj);
        }
    }
}
