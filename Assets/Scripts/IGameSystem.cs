using UnityEngine;
using System.Collections;

// 遊戲子系統共用界面
public abstract class IGameSystem
{
    protected BarrageGame barrageGame = null;
    public IGameSystem(BarrageGame barrageGame)
    {
        this.barrageGame = barrageGame;
    }

    public virtual void Initialize() { }
    public virtual void Release() { }
    public virtual void Update() { }

}
