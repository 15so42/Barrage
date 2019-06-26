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
            Debug.Log("受到攻击"+status.hp);
        }
    }

}
