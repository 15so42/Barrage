using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBullet2 : IBullet
{
    public float time = 2;
    public float timer = 0;
  

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (time >= timer)
        {
            transform.Rotate(Vector3.down * 60 * Time.deltaTime);
        }
        base.Update();
    }
    public override void Recycle()
    {
        base.Recycle();
        timer = 0;
    }
}
