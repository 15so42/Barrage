using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//涡轮两条顺向
public class ZZWeaponShotgun9 : IWeapon
{

    public override void Init()
    {
        attackSpeed = 1.0f;
        base.Init();
    }


    //射击方法，需要重写
    public override void Fire()
    {
        Debug.Log("fire");
        BarrageGame.Instance.getBarrageUtil().StartCoroutine(ZZShotgun());




    }

    IEnumerator ZZShotgun()
    {
        Vector3 vec = new Vector3(0, 0, 1);
        Vector3 vec2 = new Vector3(0, 0, -1);
        for (int i = -9; i < 36; i++)
        {
            GameObject bullet = BulletUtil.LoadBullet(shooter.GetBulletName());

            bullet.transform.position = shooter.GetPos();

            bullet.transform.forward = Quaternion.AngleAxis(21 * i, Vector3.up) * vec;
            IBullet bulletInfo = bullet.GetComponent<IBullet>();
            bulletInfo.shooter = shooter;
            bulletInfo.speed = 5;
            bulletInfo.delay = 0;

            bulletInfo.Fire();

            GameObject bullet2 = BulletUtil.LoadBullet(shooter.GetBulletName());

            bullet2.transform.position = shooter.GetPos();

            bullet2.transform.forward = Quaternion.AngleAxis(21 * i, Vector3.up) * vec2;
            IBullet bulletInfo2 = bullet2.GetComponent<IBullet>();
            bulletInfo2.shooter = shooter;
            bulletInfo2.speed = 5;
            bulletInfo2.delay = 0;

            bulletInfo2.Fire();
            yield return new WaitForSeconds(0.5f);
            if(shooter==null)
            {
                yield return null;
            }

        }
    }

}
