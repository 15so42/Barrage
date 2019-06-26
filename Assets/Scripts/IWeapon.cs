using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Iweapon理解为武器，也可以理解为弹幕形式。一个weapon类代表一种发射方法，如散弹，圆形弹，旋涡弹。在weapon类实现弹幕。
public abstract class IWeapon 
{
    public ICharacter shooter;
    public ICharacter target;

    public MyTimer timer = new MyTimer();
    public float attackSpeed = 1;


    public IWeapon()
    {

        Init();
    }

    public virtual void Init()
    {
        timer.Start(1 / attackSpeed);
    }
   
    
    //射击方法，需要重写
    public virtual void Fire()
    {
        Vector3 vec;
        if (target == null)
        {
            vec = shooter.transform.forward;
        }
        else
        {
            vec = GetVec();
        }
        
        GameObject bullet = BulletUtil.LoadBullet(shooter.bulletName);
        
        bullet.transform.position = shooter.GetPos();
        bullet.transform.forward = vec;
        bullet.GetComponent<IBullet>().shooter = shooter ;
        bullet.GetComponent<IBullet>().Fire();

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

    public virtual void Fire(Vector3 vec)
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

    //获取射击者到目标的向量。
    public Vector3 GetVec()
    {
        Vector3 vec = target.GetPos() - shooter.GetPos();
        return vec;
    }

    
}
