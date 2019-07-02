using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhWeaponShotgun1 : GhWeaponShotgun
{
    public override void Fire()
    {
        BarrageGame.Instance.getBarrageUtil().StartCoroutine(ShotGun1());
    }

    IEnumerator ShotGun1()
    {
        for (int i = 0; i < 3; i++)
        {

            base.Fire();
            yield return new WaitForSeconds(0.3f);
        }
    }

}
