using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class IMovement:MonoBehaviour
{

    public enum LastStrategy
    {
        idle,//原地不动
        random,//左右随机动
        loop
    }
   

    [Header("走到最后一个路径点后是否使用策略，如不则直接销毁")]
    public bool useStrategy;

    [Header("使用的策略，只有开启useStrategy才有效")]
    public LastStrategy strategy;
    
    [Header("路径点数组")]
    public GameObject[] targets;

    public float speed = 2.5f;

    float cameraMoveSpeed;
   

    public bool moveAble;
    public bool moveToEnd = false;
    public int index;//当前接近的路径点的Id
    MyTimer randomTimer=new MyTimer();
    Vector3 randomPos;
    Camera camera;
    


    Vector3 vec;

    private void Start()
    {
        camera = Camera.main;
        cameraMoveSpeed = BarrageGame.Instance.GetMoveSpeed();
    }

    private void Update()
    {
        
        if (moveAble)
        {
            transform.parent.Translate(new Vector3(0, 0, cameraMoveSpeed) * Time.deltaTime, Space.World);
            Move();

        }

        if (moveToEnd)
        {

            if (strategy == LastStrategy.idle)
            {
                transform.parent.Translate(new Vector3(0, 0, cameraMoveSpeed) * Time.deltaTime, Space.World);
                return;
            }
            if(strategy == LastStrategy.random)
            {
                randomTimer.Tick();
                if (randomTimer.state == MyTimer.STATE.finished)
                {
                    

                    randomPos = GetRandomPos();
                    randomTimer.Start(Random.Range(2, 6));
                    
                }
              
                transform.Translate((new Vector3(0, 0, cameraMoveSpeed)+(randomPos - transform.position).normalized*speed)*Time.deltaTime, Space.World);
            }
        }
        
    }

    //每帧调用
    public  void Move()
    {
        transform.Translate( GetVec() * speed * Time.deltaTime, Space.World);
       
        if (Vector3.Distance(transform.position, targets[index].transform.position) < 0.5f)
        {
            if (index == targets.Length - 1)
            {
                if (useStrategy==true&& strategy == LastStrategy.loop)
                {
                    index = 0;
                    return;
                }
                moveToEnd = true;
                moveAble = false;
                if (useStrategy == false)
                {

                    Debug.Log("awsl");
                    Die();

                }
                else
                {
                    if (strategy == LastStrategy.random)
                    {
                        randomTimer.Start(3);
                    }
                }
            }
            else
            {
                index++;
            }
            
        }
    }

    public Vector3 GetVec()
    {
        vec = Vector3.Slerp(vec, (targets[index].transform.position - transform.position).normalized, 0.3f);
        return vec.normalized;
    }

    public Vector3 GetRandomPos()
    {
        int x = Random.Range(-15, 15);
        int z = Random.Range(4, 10);


        randomPos = new Vector3(camera.transform.position.x,0,camera.transform.position.z) + new Vector3(x, 0, z);
        return randomPos;
    }

    public void CanMove()
    {
        moveAble = true;
    }

    public void Die()
    {
        Destroy(transform.parent.gameObject);
    }


}
