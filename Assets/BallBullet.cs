using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBullet : IBullet
{

    public void OnEnable()
    {
        BarrageGame.Instance.getBulletUtil().Recycle(this, 12);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        transform.Rotate(Vector3.up * 90 * Time.deltaTime);
    }
}
