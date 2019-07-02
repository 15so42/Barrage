using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//自瞄，搭配追踪弹即是导弹
public class YKWeaponAim : IWeapon
{
    public override void Fire()
    {
        if (IEnemy.enemys.Count > 0)
        {       
        target = BarrageUtil.RandomFecthFromList<IEnemy>(IEnemy.enemys).gameObject;
        }
        base.Fire();

    }
}
