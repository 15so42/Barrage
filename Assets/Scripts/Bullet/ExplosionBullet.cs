using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBullet : IBullet
{

    public void OnEnable()
    {
        weapon = WeaponUtil.CreateWeapon("GhWeaponShotgun");
        weapon.shooter = this;
        weapon.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        timer.Start(3);
        bulletName = "Yk_B_CubeBullet";
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
            timer.Restart();
        }
    }
}
