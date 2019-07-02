using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//混乱，随机决定子弹方向。
public class YKWeaponChaos : IWeapon
{
    public override void Fire()
    {
       
       
        

        GameObject bullet = BulletUtil.LoadBullet(shooter.GetBulletName());

        bullet.transform.position = shooter.GetPos();
        bullet.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        bullet.GetComponent<IBullet>().shooter = shooter;
        if (target)
            bullet.GetComponent<IBullet>().target = target;
        bullet.GetComponent<IBullet>().Fire();

    }
}
