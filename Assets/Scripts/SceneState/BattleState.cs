using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// 战斗状态
public class BattleState : ISceneState
{
	public BattleState(SceneStateController Controller):base(Controller)
	{
		this.StateName = "BattleState";
	}

	// 初始化，获取相关信息和物体
	public override void StateBegin()
	{
		BarrageGame.Instance.Init();
	}

	// 結束
	public override void StateEnd()
	{
		BarrageGame.Instance.Release();
	}
			
	// 更新
	public override void StateUpdate()
	{
        // 遊戲邏輯
        BarrageGame.Instance.Update();
		// Render由Unity負責

		// 遊戲是否結束
		if(BarrageGame.Instance.ThisGameIsOver())
			m_Controller.SetState(new MainMenuState(m_Controller), "MainMenuScene" );
	}
}
