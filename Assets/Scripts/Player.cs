using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPlayer
{
    public override void Fire()
    {

        weapon.Fire(transform.forward);
    }
}
