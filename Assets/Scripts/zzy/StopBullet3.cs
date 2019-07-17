using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBullet3 : IBullet
{
    public float time = 2;
    public float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>= time)
        {
            transform.Rotate(Vector3.down * 60 * Time.deltaTime);
            if (timer > 30)
            {
                Recycle();
            }
        }
        base.Update();
    }
    public override void Recycle()
    {
        base.Recycle();
        timer = 0;
    }
}
