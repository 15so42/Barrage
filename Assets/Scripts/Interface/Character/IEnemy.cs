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
    [Header("存活期间能攻击的次数，-1为无限次")]
    public int count=-1;
    [Header("探测玩家的范围。当玩家与这个敌距离小于这个值时敌人开始移动并攻击，只比较z轴方向的距离")]
    public float range = 30;


    public MyTimer waitTimer = new MyTimer();
    
    IMovement movement;

    Camera mainCamera;
    

    bool closeCamera = false;

    // Start is called before the first frame update
    public override void Init()
    {
        movement = GetComponent<IMovement>();
        base.Init();
        status.MaxHp = maxHp;
        status.hp = maxHp;

        player = GameObject.FindGameObjectWithTag("Player");
        weapon.count = count;
        weapon.target = player;
        mainCamera = Camera.main;


    }

    private void Update()
    {
        if (GetDistance() < range&&closeCamera==false)
        {
            closeCamera = true;
            ReadyAttack();
        }

        if (closeCamera)
        {
            waitTimer.Tick();
            if (waitTimer.state != MyTimer.STATE.finished)
                return;
           
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
        GameObject explosion = BulletUtil.LoadBullet("ExplosionParticle");
        explosion.transform.position = transform.position;
        explosion.GetComponent<IBullet>().Fire();
        DropPoint();
        weapon = null;
        waitTimer = null;
        enemys.Remove(this);

        if (tag == "Boss")
        {
            GUIManager.ShowView("GameWinUI", Vector3.zero);
            Time.timeScale = 0.1f;
        }

        Destroy(gameObject);

    }

    public float GetDistance()
    {
        return Mathf.Abs(transform.position.z- mainCamera.transform.position.z);
    }


    public void DropPoint()
    {
        //随机掉落点数
        int count = UnityEngine.Random.Range(-2, 5);
        if (count <= 0)
            return;


        GameObject bullet=BulletUtil.LoadBullet(UnityEngine.Random.Range(0,2)==0?"ppt":"hpt");
        IBullet bulletInfo = bullet.GetComponent<IBullet>();
        bulletInfo.shooter = this;
        bullet.transform.position = transform.position;
        bulletInfo.Fire();
    }

}
