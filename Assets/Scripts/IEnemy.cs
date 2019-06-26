using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class IEnemy : ICharacter
{

    public ICharacter player;
    public int maxHp = 1;

    //不能一出现就攻击，需要等待一会
    public float waitTime=3;

    public MyTimer waitTimer = new MyTimer();


    // Start is called before the first frame update
    public override void Init()
    {
        base.Init();
        status.MaxHp = maxHp;
        status.hp = maxHp;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
        weapon.target = player;
        waitTimer.Start(waitTime);
        


    }

    

    

    public virtual void Walk()
    {

    }

    public  void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {

            status.GetDamage(1);
        }
    }


}
