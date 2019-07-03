using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class IEnemy : ICharacter
{

    public static List<IEnemy> enemys=new List<IEnemy>();

    public GameObject player;
    public int maxHp = 1;

    //不能一出现就攻击，需要等待一会
    public float waitTime=3;

    public MyTimer waitTimer = new MyTimer();

    public IMovement movement;

    bool closePlayer = false;

    // Start is called before the first frame update
    public override void Init()
    {
        movement = GetComponent<IMovement>();
        base.Init();
        status.MaxHp = maxHp;
        status.hp = maxHp;

        player = GameObject.FindGameObjectWithTag("Player");
       
        weapon.target = player;
        


    }

    private void Update()
    {
        if (GetDistance() < 30&&closePlayer==false)
        {
            closePlayer = true;
            ReadyAttack();
        }

        if (closePlayer)
        {
            weapon.Tick();
        }
      
    }

    public void ReadyAttack()
    {
        movement.CanMove();
        waitTimer.Start(waitTime);
        enemys.Add(this);
    }

    


    public  void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {

            status.GetDamage(1);
            other.GetComponent<IBullet>().Recycle();
            if (status.isDied())
            {
                Die();
                
            }
            
        }
    }

    public void Die()
    {
        
        weapon = null;
        waitTimer = null;
        enemys.Remove(this);
        Destroy(gameObject);

    }

    public float GetDistance()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }


}
