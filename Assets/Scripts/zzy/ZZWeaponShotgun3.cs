using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//散弹三波3
public class ZZWeaponShotgun3 : IWeapon
{
    public override void Init()
    {
        attackSpeed = 0.1f;
        base.Init();
    }

    private const int V = 3;


    //射击方法，需要重写
    public override void Fire()
    {

        BarrageGame.Instance.getBarrageUtil().StartCoroutine(ZZShotgun());



    }
    IEnumerator ZZShotgun()
    {

        Vector3 vec = new Vector3(0, 0, -1);
        Quaternion leftrota = Quaternion.AngleAxis(-10, Vector3.up);
        Quaternion rightrota = Quaternion.AngleAxis(10, Vector3.up);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 9; j < 14; j++)
            {

                switch(j){
                    case 9:
                        GameObject bullet = BulletUtil.LoadBullet(shooter.GetBulletName());

                        bullet.transform.position = shooter.GetPos();

                        bullet.transform.forward =  vec;
                        IBullet bulletInfo = bullet.GetComponent<IBullet>();
                        bulletInfo.shooter = shooter;
                        bulletInfo.Fire();
                        break;
                    case 10:
                        GameObject bullet2 = BulletUtil.LoadBullet(shooter.GetBulletName());

                        bullet2.transform.position = shooter.GetPos();

                        bullet2.transform.forward = leftrota * vec;
                        IBullet bulletInfo2 = bullet2.GetComponent<IBullet>();
                        bulletInfo2.shooter = shooter;
                        bulletInfo2.Fire();
                        break;
                    case 11:
                        GameObject bullet3 = BulletUtil.LoadBullet(shooter.GetBulletName());

                        bullet3.transform.position = shooter.GetPos();

                        bullet3.transform.forward = rightrota * vec;
                        IBullet bulletInfo3 = bullet3.GetComponent<IBullet>();
                        bulletInfo3.shooter = shooter;
                        bulletInfo3.Fire();
                        break;
                    case 12:
                        GameObject bullet4 = BulletUtil.LoadBullet(shooter.GetBulletName());

                        bullet4.transform.position = shooter.GetPos();

                        bullet4.transform.forward = rightrota*rightrota * vec;
                        IBullet bulletInfo4 = bullet4.GetComponent<IBullet>();
                        bulletInfo4.shooter = shooter;
                        bulletInfo4.Fire();
                        break;
                    case 13:
                        GameObject bullet5 = BulletUtil.LoadBullet(shooter.GetBulletName());

                        bullet5.transform.position = shooter.GetPos();

                        bullet5.transform.forward = leftrota*leftrota  * vec;
                        IBullet bulletInfo5 = bullet5.GetComponent<IBullet>();
                        bulletInfo5.shooter = shooter;
                        bulletInfo5.Fire();
                        break;
                }
               

            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    ////朝某个方向
    //public override void Fire(Vector3 vec)
    //{
    //    //从对象池里取出子弹
    //    GameObject bullet = BulletUtil.LoadBullet(shooter.bulletName);

    //    //将取出的子弹的位置设置为射击者的位置
    //    bullet.transform.position = shooter.GetPos();
    //    //使子弹的forward向量等于射击者到目标的向量,也就是说让子弹正面朝向目标
    //    bullet.transform.forward = vec;
    //    //将子弹的攻击者设置为射击者
    //    bullet.GetComponent<IBullet>().shooter = shooter;
    //    //调用子弹的发射函数。可在子弹的发射函数中设置发射延迟或者启动一个新的函数或协程。
    //    bullet.GetComponent<IBullet>().Fire();

    //}
}
