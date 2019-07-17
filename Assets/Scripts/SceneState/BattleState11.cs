using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// 战斗状态
public class BattleState11 : ISceneState
{
    public BattleState11(SceneStateController Controller) : base(Controller)
    {
        this.StateName = "BattleState11";
        BarrageGame.Instance.sceneStateController = m_Controller;
    }

    //初始化，获取相关信息和物体
    public override void StateBegin()
    {
        BarrageGame.Instance.Init();
    }

    //結束
    public override void StateEnd()
    {
        BarrageGame.Instance.Release();
        BulletPool.bullets.Clear();
        IEnemy.enemys.Clear();
    }

    //更新
    public override void StateUpdate()
    {
        // 遊戲邏輯
        BarrageGame.Instance.Update();


        // Render由Unity負責

        // 遊戲是否結束
        if (BarrageGame.Instance.ThisGameIsOver())
        {

            Debug.Log("游戏结束");
            m_Controller.SetState(new MainMenuState(m_Controller), "MainMenuScene");
        }

        if (BarrageGame.Instance.GameIsFinish())
        {
            Debug.Log("游戏结束");
            m_Controller.SetState(new BattleState12(m_Controller), "Level1-2");
        }
    }
}
