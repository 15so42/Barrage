using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhWeaponRingOnce : IWeapon
{
    Vector3 vec = new Vector3(0, 0, 1);
    public override void Fire()
    {
       GhRing();
    }

    void GhRing()
    {
          
            for (int j = 0; j < 18; j++)
            {
                GameObject bullet = BulletUtil.LoadBullet(shooter.GetBulletName());

                bullet.transform.position = shooter.GetPos();
                bullet.transform.forward = Quaternion.AngleAxis(20 * j, Vector3.up) * vec;
            IBullet bulletInfo = bullet.GetComponent<IBullet>();
            bulletInfo.shooter = shooter;
            bulletInfo.speed = 5;
                bulletInfo.Fire();
            

            }
            vec = Quaternion.AngleAxis(10 , Vector3.up) * vec;

    }

    
}
