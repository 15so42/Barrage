using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon2 : IWeapon
{
    //射击方法，需要重写
    public override void Fire()
    {
        Vector3 forward = new Vector3(0, 0, 1);
        Vector3 vec = new Vector3(0, 0, 1);
        for (int i = -1; i < 2; i++)
        {
            if (i == 0)
            {
                continue;
            }
            GameObject bullet = BulletUtil.LoadBullet(shooter.GetBulletName());

            bullet.transform.position = shooter.GetPos();

            bullet.transform.forward = Quaternion.AngleAxis(30 * i, Vector3.up) * vec;

            IBullet bulletInfo = bullet.GetComponent<IBullet>();
            bulletInfo.shooter = shooter;
            
            bulletInfo.delay = 0;

            bulletInfo.Fire();
          

        }
        for (int i = -1; i < 2; i++)
        {

            GameObject bullet = BulletUtil.LoadBullet(shooter.GetBulletName());

            bullet.transform.position = shooter.GetPos() + new Vector3(i * 0.5f, 0, 0);

            bullet.transform.forward = new Vector3(0, 0, 1);
            
            IBullet bulletInfo = bullet.GetComponent<IBullet>();
            bulletInfo.shooter = shooter;



            bulletInfo.Fire();


        }



    }
}
