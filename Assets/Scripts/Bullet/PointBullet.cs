using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBullet : IBullet
{
    public float t = 0;
    MyTimer recycleTimer = new MyTimer();
    public override void Init()
    {
        base.Init();
        speed = 4;
        recycleTimer.Start(10);
    }

    // Update is called once per frame
    void Update()
    {
        recycleTimer.Tick();
        if (shootAble)
        {
            t += Time.deltaTime;
            transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime);
            speed -= 0.0098f * t;
        }
            
        transform.Translate(new Vector3(0, 0, 1) * cameraMoveSpeed * Time.deltaTime, Space.World);
        if (recycleTimer.state==MyTimer.STATE.finished)
        {
            Recycle();
        }
    }

    public override void Recycle()
    {
        base.Recycle();
        t = 0;
        speed = 4;
        recycleTimer.Restart();
    }
}
