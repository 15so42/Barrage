using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : IBullet
{
    public int r;
    public override void Init()
    {
        base.Init();
        r = (Random.Range(-1, 3) >= 1 ? 1 : -1) * Random.Range(10,60);
        
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
            
        Vector3 a = transform.position;
        Vector3 b = target.transform.position;

        Vector3 center = (a + b) * 0.5f;
       
        
        center += new Vector3(r,0,0f);

        Vector3 vecA = a - center;
        Vector3 vecB = b - center;

        Vector3 vec = Vector3.Slerp(vecA, vecB, 0.05f);
        vec += center;
        transform.forward = vec - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, vec, 0.1f);
    }
}
