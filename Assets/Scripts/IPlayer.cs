using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : ICharacter
{
    public static StageSystem stageSystem = null;

    public  void OnTriggerEnter(Collider other)
    {

        if (other.tag == "EnemyBullet")
        {
            status.GetDamage(1);
            EventManager.TriggerEvent("playerBeDamaged", new ArrayList { status.hp });
            if (status.hp <= 0)
                Die();
            
            
        }
    }

    private void Update()
    {
        weapon.Tick();
    }


    public void Die()
    {
        EventManager.TriggerEvent("playerDied",null);
        Debug.Log("真鸡儿菜");
    }

   
}
