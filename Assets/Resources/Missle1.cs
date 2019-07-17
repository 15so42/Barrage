using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle1 : Missle
{
    
   
    


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (IEnemy.enemys.Count > 0)
            {
                
                target = BarrageUtil.RandomFecthFromList<IEnemy>(IEnemy.enemys).gameObject;
            }
            base.Update();
            return;
        }

        transform.forward = Vector3.Slerp(transform.forward, target.transform.position - transform.position, 0.5f / Vector3.Distance(transform.position, target.transform.position));
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void OnBecameInvisible()
    {
        
    }
}
