using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bullet即是子弹类，在里面的update函数里表示移动逻辑，如直线，波形，折现型。
public class IBullet : MonoBehaviour,IShootAble
{
    public float speed = 10;
    //延迟
    public float delay = 0;
    
    public IShootAble shooter;
    public GameObject target;
    public bool shootAble;
    public MyTimer timer=new MyTimer();
    string bulletName;
    protected Camera camera;
    protected float cameraMoveSpeed;

    public void Start()
    {
        Init();

    }

    public virtual void Init()
    {
        camera = Camera.main;
        cameraMoveSpeed = BarrageGame.Instance.GetMoveSpeed();
    }

    [Header("回收的开关，如果这颗子弹是手工弹幕中的子弹且弹幕出现了异常，请不要勾选。如无异常，则说明系统自动纠错，请无视此处。")]

    //在回收时判断是否有父物体，当有父物体时基本上说明是手工弹幕，则阻止回收
    public bool recycleAble=true;
    

    public IWeapon weapon;

   

    

    public string GetName()
    {
        return gameObject.name;
    }


    public void Fire()
    {
        shootAble = true;
    }
    // Update is called once per frame
    public void Update()
    {
        if(shootAble)
        transform.Translate( Vector3.forward* speed * Time.deltaTime);
        transform.Translate(new Vector3(0,0,1) * cameraMoveSpeed * Time.deltaTime, Space.World);
        if (OutOfScreen()&&recycleAble)
        {
            Recycle();
        }
    }



    public virtual void Recycle()
    {

        if (GetObj().transform.parent==null)
        {
            if (recycleAble == true)
            {

                BulletPool.Put(gameObject);
                gameObject.SetActive(false);
            }
           
        }
        
       
        
    }

    public bool OutOfScreen()
    {
        if (Mathf.Abs(transform.position.x) > 25 || Mathf.Abs(transform.position.z - camera.transform.position.z) > 15)
        {
            return true;
        }
        return false;
    }
   
    

    public GameObject GetObj()
    {
        return gameObject;
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }

    public string GetBulletName()
    {
        return bulletName;
    }

    public void Die()
    {
        Recycle();
    }
}
