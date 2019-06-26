using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer
{
    public enum STATE
    {
        idle,
        running,
        finished
    }

    public STATE state=STATE.idle;

    public float duration = 0.1f;
    public float elapsed = 0;
    public bool isExtending;

    public void Tick()
    {
        if(state==STATE.running)
        {
            elapsed += Time.deltaTime;
            if (elapsed > duration)
            {
                state = STATE.finished;
            }
        }
        
    }

    public void Start(float duration)
    {
        state = STATE.running;
        elapsed = 0;
        this.duration = duration;

    }
    public void Restart()
    {
        Start(duration);
    }
}
