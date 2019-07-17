using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBullet4 : IBullet
{
    public float time=2;
    


    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(shooter.GetObj().name);
        transform.RotateAround(shooter.GetPos() , new Vector3(0, 1, 0), 80f* Time.deltaTime);
        base.Update();
    }

}
