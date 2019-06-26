using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhWeaponShotgun : IWeapon
{

    int count = 4;
    //射击方法，需要重写
    public override void Fire()
    {
        Vector3 vec = GetVec();

        
        for (int i = -4; i < 5; i++)
        {
            GameObject bullet = BulletUtil.LoadBullet(shooter.bulletName);

            bullet.transform.position = shooter.GetPos();
            
            bullet.transform.forward = Quaternion.AngleAxis(20*i, Vector3.up)*vec;
            IBullet bulletInfo = bullet.GetComponent<IBullet>();
            bulletInfo.shooter = shooter;
            bulletInfo.speed = 10;
            bulletInfo.delay = 3;
            bulletInfo.Fire();
        }


    }

    public void Tick()
    {
        timer.Tick();
        if (timer.state == MyTimer.STATE.finished)
        {
            if (count > 0)
            {
                Fire();
                count--;
                timer.Restart();
            }
            else
            {

                attackSpeed = 0.5f;
                timer.duration = 1.0f / attackSpeed;
                Fire();
                timer.Restart();

            }


        }
    }
 

    //朝某个方向
    public override void Fire(Vector3 vec)
    {
        //从对象池里取出子弹
        GameObject bullet = BulletUtil.LoadBullet(shooter.bulletName);

        //将取出的子弹的位置设置为射击者的位置
        bullet.transform.position = shooter.GetPos();
        //使子弹的forward向量等于射击者到目标的向量,也就是说让子弹正面朝向目标
        bullet.transform.forward = vec;
        //将子弹的攻击者设置为射击者
        bullet.GetComponent<IBullet>().shooter = shooter;
        //调用子弹的发射函数。可在子弹的发射函数中设置发射延迟或者启动一个新的函数或协程。
        bullet.GetComponent<IBullet>().Fire();

    }
}
