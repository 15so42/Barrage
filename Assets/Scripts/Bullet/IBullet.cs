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
    public string bulletName;


    public void Start()
    {
        Init();
    }

    public virtual void Init()
    {

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
        transform.Translate(Vector3.forward* speed * Time.deltaTime);
    }



    public void Recycle()
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
    public void OnBecameInvisible()
    {

        Recycle();
      
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
