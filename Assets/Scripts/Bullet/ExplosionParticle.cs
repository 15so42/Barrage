using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : IBullet
{
    public void Fire()
    {
        GetComponent<ParticleSystem>().Play();
    }

    
}
