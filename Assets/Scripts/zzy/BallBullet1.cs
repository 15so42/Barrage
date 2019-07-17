using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBullet1 : IBullet
{
    public float time=18;
    public float rTimer=0;

    // Update is called once per frame
    void Update()
    {
        rTimer += Time.deltaTime;
        if (rTimer >= time)
        {
            rTimer = 0;
            recycleAble = true;
            Recycle();
        }
        base.Update();
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);
    }
    public override void Recycle()
    {
        base.Recycle();
        rTimer = 0;
    }
}
