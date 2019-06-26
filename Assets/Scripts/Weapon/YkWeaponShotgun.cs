using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YkWeaponShotgun : IWeapon
{

    public override void Init()
    {
        attackSpeed = 0.1f;
        base.Init();
    }


    //射击方法，需要重写
    public override void Fire()
    {
        Debug.Log("fire");
        BarrageGame.Instance.getBarrageUtil().StartCoroutine(YkShotgun());
        
       


    }

    IEnumerator YkShotgun()
    {
        Vector3 vec = GetVec();
        for (int i = -36; i < 36; i++)
        {
            GameObject bullet = BulletUtil.LoadBullet(shooter.bulletName);

            bullet.transform.position = shooter.GetPos();

            bullet.transform.forward = Quaternion.AngleAxis(20 * i, Vector3.up) * vec;
            IBullet bulletInfo = bullet.GetComponent<IBullet>();
            bulletInfo.shooter = shooter;
            bulletInfo.speed = 5;
            bulletInfo.delay = 0;

            bulletInfo.Fire();
            yield return new WaitForSeconds(0.1f);

        }
    }

    public void Tick()
    {
        timer.Tick();
        
        if (timer.state == MyTimer.STATE.finished)
        {
          
                Fire();
                timer.Restart();
        }
    }
 

  
}
