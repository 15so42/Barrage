using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : IEnemy
{
    int count = 4;

    public override void Init()
    {

        base.Init();
        
      
    }
   
    public void Update()
    {
        waitTimer.Tick();
        if (waitTimer.state != MyTimer.STATE.finished)
            return;
        weapon.Tick();

    }
}
