using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : IBullet
{
    public int r;
    public GameObject trail;
    

    public override void Init()
    {
        base.Init();
        r = (Random.Range(-1, 3) >= 1 ? 1 : -1) * Random.Range(10,60);
        
    }
    public void OnEnable()
    {
        GameObject tmpTrail = Instantiate(trail);
        UnityTool.Attach(gameObject, tmpTrail, Vector3.zero);

        if (IEnemy.enemys.Count > 0)
        {
            target = BarrageUtil.RandomFecthFromList<IEnemy>(IEnemy.enemys).gameObject;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        if (target == null)
        {
            
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


    public override void Recycle()
    {
        if (transform.parent == null)
        {
            if (recycleAble == true)
            {
                Transform trail = transform.GetChild(0);
                trail.SetParent(null);
                Destroy(trail.gameObject, 3);
                BulletPool.Put(gameObject);
                gameObject.SetActive(false);
            }

        }
    }

   
 


}
