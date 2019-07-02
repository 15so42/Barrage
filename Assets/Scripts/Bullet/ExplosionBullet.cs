using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBullet : IBullet
{
    
    public float explosionTime = 2;
    [Header("散弹数量")]
    public float count = 3;
    public void OnEnable()
    {
        weapon = WeaponUtil.CreateWeapon("GhWeaponShotgun");
        weapon.shooter = this;
        weapon.target = GameObject.FindGameObjectWithTag("Player");
        
        timer.Start(explosionTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootAble)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timer.Tick();
        if (timer.state == MyTimer.STATE.finished)
        {
            
            weapon.Fire();
            timer.Stop();
        }
    }

    public void OnBecameInvisible()
    {

        Recycle();

    }
}
