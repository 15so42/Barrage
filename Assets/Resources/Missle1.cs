using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle1 : IBullet
{
    public int r;
    public override void Init()
    {
        base.Init();
        r = (Random.Range(-1, 3) >= 1 ? 1 : -1) * Random.Range(1, 10);

    }
    public void OnEnable()
    {
        GetComponent<TrailRenderer>().Clear();
       
    }
    


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
}
