using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//圆形三波36
public class ZZWeaponShotgun1 : IWeapon
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
        

        for (int i = 0; i>=0; i++)
        {
            Vector3 vec = new Vector3(0,0,1);
            int tj = Random.Range(-8, 20);
            for (int j = -8; j < 28; j++)
            {
                GameObject bullet;

                if (i % 2 == 1)
                {
                    bullet = BulletUtil.LoadBullet("红边圆");
                }
                else
                {
                    bullet = BulletUtil.LoadBullet("蓝边圆");
                }
               

                
                bullet.transform.position = shooter.GetPos();

                bullet.transform.forward = Quaternion.AngleAxis(10 * j, Vector3.up) * vec;
                IBullet bulletInfo = bullet.GetComponent<IBullet>();
                bulletInfo.shooter = shooter;
                bulletInfo.speed = 1.0f;
                bulletInfo.Fire();
 
            }

            Vector3 flowerVec = new Vector3(0, 0, 1);
            flowerVec = Quaternion.AngleAxis(Random.Range(0,36)*10, Vector3.up) * vec;
            for (int j=0;j< 7; j++)
            {
                GameObject bullet;

                if (i % 2 == 1)
                {
                    bullet = BulletUtil.LoadBullet("红花");

                }
                else
                {
                    bullet = BulletUtil.LoadBullet("蓝花");
                }




                bullet.transform.position = shooter.GetPos() + new Vector3(0, 0.3f, 0); ;
                
                bullet.transform.forward = Quaternion.AngleAxis(10 * j, Vector3.up) * flowerVec;
                IBullet bulletInfo = bullet.GetComponent<IBullet>();

                bulletInfo.shooter = shooter;
               
                bulletInfo.speed = 1.0f;
                bulletInfo.Fire();

            }
            yield return new WaitForSeconds(3.5f);
        }
    }

    
}
