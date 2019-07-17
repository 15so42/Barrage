using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageGame
{

    public bool gameOver=false;
    public StageSystem stageSystem;
    public GameObject playerObj;
    private BarrageUtil barrageUtil;
    private BulletUtil bulletUtil;
    public SceneStateController sceneStateController;
    //全局移动速度
    public float moveSpeed=2;
    public bool gameFinish=false;

    //对象池子弹每种子弹的上限数量
    public static int BulletPoolCount=64;

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


    //返回BulletUtil的mono类，当项目中存在时直接调用，不存在则新建空物体并挂载脚本，更新barrageUtil为新的BarrageUtil
    public BulletUtil getBulletUtil()
    {
        if (bulletUtil != null)
        {
            return bulletUtil;
        }
        BulletUtil newBulletUtil = GameObject.FindObjectOfType<BulletUtil>();
        if (newBulletUtil == null)
        {
            GameObject empty = new GameObject();
            newBulletUtil = empty.AddComponent<BulletUtil>();

        }
        bulletUtil = newBulletUtil;
        return newBulletUtil;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }


    public bool ThisGameIsOver()
    {
        return gameOver;
    }

    public bool GameIsFinish()
    {
        return gameFinish;
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

    public void GameOver()
    {
        GUIManager.ShowView("GameOverUI", Vector3.zero);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject.Destroy(Player);
        GameObject Aid = GameObject.FindGameObjectWithTag("Aid");
        GameObject.Destroy(Aid);
        Time.timeScale = 0.1f;

        
    }
}
