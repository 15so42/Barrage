using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bullet即是子弹类，在里面的update函数里表示移动逻辑，如直线，波形，折现型。
public class IBullet : MonoBehaviour
{
    public float speed = 10;
    //延迟
    public float delay = 0;
    

    public bool shootAble;
    public ICharacter shooter;

    public GameObject GetObj()
    {
        return gameObject;
    }

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
        
        
        
        BulletPool.Put(gameObject);
        gameObject.SetActive(false);
        
    }
    public void OnBecameInvisible()
    {
        
        Recycle();
      
    }
}
