using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAid : ICharacter,IShootAble
{
    GameObject player;
    int x;

    public override void Init()
    {
        base.Init();
        player = GameObject.FindGameObjectWithTag("Player");
        x = Random.Range(-1, 3) >= 1 ? 1 : -1;

    }
    
    public override void Fire()
    {
        
        weapon.Fire();
    }

    public override void CharacterUpdate()
    {
        base.CharacterUpdate();
        //transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(x, 0, 0), 0.1f);
        if (player)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.1f);
        }
      
    }
    
    
}
