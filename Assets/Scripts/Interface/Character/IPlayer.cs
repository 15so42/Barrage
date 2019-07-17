using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : ICharacter
{

    public List<IWeapon> weapons = new List<IWeapon>();

    public static StageSystem stageSystem = null;
    public int ppt = 0;
    int tmpPpt = 0;
    public int hpt = 0;
    public IAid aid;

    public override void Init()
    {
        base.Init();
        //初始武器
        weapons.Add(weapon);
        aid = GameObject.FindGameObjectWithTag("Aid").GetComponent<IAid>();
        status.master = "player";
        status.hp = 3;

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "EnemyBullet")
        {
            status.GetDamage(1);
            
            if (status.hp <= 0)
                Die();


        }
        if (other.tag == "ppt")
        {
            ppt += 5;
            other.GetComponent<IBullet>().Recycle();
        }
        if (other.tag == "hpt")
        {
            hpt += 1;
            if (hpt % 3 == 0&&status.hp<3)
            {

                status.GetDamage(-1);
            }
            other.GetComponent<IBullet>().Recycle();
        }
    }

    public override void Update()
    {

        for (int i = 0; i < weapons.Count; i++)
        {

            weapons[i].Tick();
        }

        //根据分数切换武器
        if (tmpPpt != 15 && ppt == 15)
        {
            weapons.Clear();
            AddWeapon("PlayerWeapon0");
            tmpPpt = 15;
            aid.attackSpeed += 2;
            aid.weapon.timer.Start(1f/aid.attackSpeed);
        }
        
        if (tmpPpt != 30 && ppt == 30)
        {
            weapons.Clear();
            AddWeapon("PlayerWeapon1");
            tmpPpt = 30;
            aid.attackSpeed += 4;
            aid.weapon.timer.Start(1f / aid.attackSpeed);
        }

        if (tmpPpt!=60&&ppt == 60)
        {
            weapons.Clear();
            AddWeapon("PlayerWeapon2");
            tmpPpt = 60;
            aid.attackSpeed += 6;
            aid.weapon.timer.Start(1f / aid.attackSpeed);
        }


    }

   



    public void Die()
    {
        EventManager.TriggerEvent("playerDied",null);
        GameObject explosion = BulletUtil.LoadBullet("ExplosionParticle");
        explosion.transform.position = transform.position;
        explosion.GetComponent<IBullet>().Fire();
        BarrageGame.Instance.GameOver();

    }

   

    public void AddWeapon(string weaponName)
    {
        
        weapon = (IWeapon)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(weaponName, false);
        weapon.shooter = this;
        weapon.SetAttackSpeed(attackSpeed);
        weapons.Add(weapon);
    }
    
   
}
