using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//球形3波36
public class ZZWeaponShotgun12 : IWeapon
{
    

    


    //射击方法，需要重写
    public override void Fire()
    {

        ZZShotgun();



    }
    void ZZShotgun()
    {
        IBullet[] bullets = new IBullet[40];
        Vector3 vec = new Vector3(0, 0, 1);
            for (int i = 0; i <36; i++)
            {
                GameObject bullet = BulletUtil.LoadBullet(shooter.GetBulletName());

                bullet.transform.position = shooter.GetPos();

                bullet.transform.forward = Quaternion.AngleAxis(10 * i, Vector3.up) * vec;
                IBullet bulletInfo = bullet.GetComponent<IBullet>();
                bulletInfo.shooter = shooter;
                bulletInfo.Fire();
                bullets[i] = bulletInfo;
            bulletInfo.speed = 5.0f;
            }
            
    }

    
}
