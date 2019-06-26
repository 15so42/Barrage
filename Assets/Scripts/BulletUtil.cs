using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUtil : MonoBehaviour
{
    public static GameObject LoadBullet(string bulletName)
    {
        GameObject bullet = null;
        //先从对象池中取出
        bullet = BulletPool.Get(bulletName);
        if (bullet == null)
        {
            
            Object b = Resources.Load("Bullet/" + bulletName);

            bullet = GameObject.Instantiate((GameObject)b);
        }
        return bullet;

    }
}
