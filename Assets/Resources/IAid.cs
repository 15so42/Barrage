using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAid : ICharacter,IShootAble
{
    GameObject player;

    public override void Init()
    {
        base.Init();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    
    public override void Fire()
    {
        
        weapon.Fire();
    }

    public override void CharacterUpdate()
    {
        
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.1f);
    }
}
