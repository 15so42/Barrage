using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageGame
{

    public bool gameOver;
    public StageSystem stageSystem;
    public GameObject playerObj;
    private BarrageUtil barrageUtil;

    //返回BarrageUtil的mono类，当项目中存在时直接调用，不存在则新建空物体并挂载脚本，更新barrageUtil为新的BarrageUtil
    public BarrageUtil getBarrageUtil()
    {
        if (barrageUtil != null)
        {
            return barrageUtil;
        }
        BarrageUtil newBarrageUtil = GameObject.FindObjectOfType<BarrageUtil>();
        if (newBarrageUtil == null)
        {
            GameObject empty = new GameObject();
            newBarrageUtil=empty.AddComponent<BarrageUtil>();
            
        }
        barrageUtil = newBarrageUtil;
        return newBarrageUtil;
    }


    
    public bool ThisGameIsOver()
    {
        return gameOver;
    }

    //------------------------------------------------------------------------
    // Singleton模版
    private static BarrageGame _instance;
    public static BarrageGame Instance
    {
        get
        {
            if (_instance == null)
                _instance = new BarrageGame();
            return _instance;
        }
    }

    public void Init()
    {
        //playerObj = GameObject.FindGameObjectWithTag("player");
    }

    public void Release()
    {

    }
   

    // Update is called once per frame
    public void Update()
    {
        
    }
}
