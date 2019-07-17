using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//圆形三波36
public class ZZWeaponShotgun13 : IWeapon
{
    

    


    //射击方法，需要重写
    public override void Fire()
    {

        BarrageGame.Instance.getBarrageUtil().StartCoroutine(ZZShotgun());



    }
    IEnumerator ZZShotgun()
    {


        for (int i = 0; i < 4; i++)
        {
            Vector3 vec = new Vector3(0, 0, 1);
            for (int j = -8; j < 28; j++)
            {
                GameObject bullet;
                bullet = BulletUtil.LoadBullet(shooter.GetBulletName());

                bullet.transform.position = shooter.GetPos();

                bullet.transform.forward = Quaternion.AngleAxis(10 * j, Vector3.up) * vec;
                IBullet bulletInfo = bullet.GetComponent<IBullet>();
                bulletInfo.shooter = shooter;
                bulletInfo.speed = 1.5f;
                bulletInfo.Fire();

            }


            yield return new WaitForSeconds(1.0f);
        }
    }
}

    

