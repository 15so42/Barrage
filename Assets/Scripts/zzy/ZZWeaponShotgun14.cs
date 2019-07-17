using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//圆形三波36
public class ZZWeaponShotgun14 : IWeapon
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
        

        for (int i = 0; i < 4; i++)
        {
            Vector3 vec = new Vector3(0,0,1);
            
            Vector3 flowerVec = new Vector3(0, 0, 1);
            flowerVec = Quaternion.AngleAxis(Random.Range(0,36)*10, Vector3.up) * vec;
            for (int j=0;j< 7; j++)
            {
                GameObject bullet;
                bullet = BulletUtil.LoadBullet(shooter.GetBulletName());
              

               


                bullet.transform.position = shooter.GetPos();
                
                bullet.transform.forward = Quaternion.AngleAxis(10 * j, Vector3.up) * flowerVec;
                IBullet bulletInfo = bullet.GetComponent<IBullet>();

                bulletInfo.shooter = shooter;
               
                bulletInfo.speed = 1.5f;
                bulletInfo.Fire();

            }
            yield return new WaitForSeconds(2.0f);
        }
    }

    
}
