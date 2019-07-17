using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加载资源
/// </summary>
public class ResourceManager
{
    #region 单例
    private static ResourceManager _Instance = null;
    public static ResourceManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new ResourceManager();
            }
            return _Instance;
        }
    }
    #endregion

    private string path = "Prefabs/";
   
   
}
