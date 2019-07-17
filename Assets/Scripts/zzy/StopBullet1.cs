using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBullet1 : IBullet
{
    public float time = 4;
    public float timer = 0;

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= time)
        {
            transform.Rotate(Vector3.down * 360 * Time.deltaTime);
            if (timer > 15)
            {
                Recycle();
            }
           
        }
        base.Update();
        transform.Rotate(Vector3.down * 60 * Time.deltaTime);

    }

    public override void Recycle()
    {
        base.Recycle();
        timer = 0;
    }
}
