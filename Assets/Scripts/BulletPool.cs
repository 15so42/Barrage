using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static List<GameObject> bullets=new List<GameObject>();

    public static GameObject Get(string name)
    {
        for(int i = 0; i < bullets.Count; i++)
        {
            if(bullets[i].name==name||bullets[i].name==name + "(Clone)")
            {
                
               
                GameObject obj = bullets[i];
               
                obj.SetActive(true);
                bullets.RemoveAt(i);
                return obj;
            }
        }
        return null;
    }
    public static void Put(GameObject obj)
    {
        bullets.Add(obj);
    }
}
