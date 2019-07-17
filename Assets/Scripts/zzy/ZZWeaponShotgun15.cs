using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//缓慢boss收缩圆

public class ZZWeaponShotgun15 : IWeapon
{


    int shootCount = 0;
    Vector3 vec1 = new Vector3(0, 0, 1);

    //射击方法，需要重写
    public override void Fire()
    {

        ZZShotgun();



    }
    void ZZShotgun()
    {
        IBullet[] bullets = new IBullet[40];
        Vector3 vec = new Vector3(0, 0, 1);
            for (int i = 0; i <18; i++)
            {
                GameObject bullet = BulletUtil.LoadBullet(shooter.GetBulletName());

                bullet.transform.position = shooter.GetPos();

                bullet.transform.forward = Quaternion.AngleAxis(20 * i, Vector3.up) * vec;
                IBullet bulletInfo = bullet.GetComponent<IBullet>();
                bulletInfo.shooter = shooter;
                bulletInfo.Fire();
                bullets[i] = bulletInfo;
            bulletInfo.speed = 5.0f;
           
            }

        if (count % 2 == 0)
        {

        
            for (int j = 0; j < 18; j++)
            {
                GameObject bullet = BulletUtil.LoadBullet("米粒");

                bullet.transform.position = shooter.GetPos();
                bullet.transform.forward = Quaternion.AngleAxis(20 * j, Vector3.up) * vec1;
                IBullet bulletInfo = bullet.GetComponent<IBullet>();
                bulletInfo.shooter = shooter;
                bulletInfo.speed = 5;
                bulletInfo.Fire();


            }
            vec1 = Quaternion.AngleAxis(10, Vector3.up) * vec1;
        }
    }

    
}
