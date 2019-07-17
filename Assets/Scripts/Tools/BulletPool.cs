using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    public static List<GameObject> bullets=new List<GameObject>();

    //创建一个字典，维护子弹名和数量，决定子弹可存放对象池数量上限。否则当一次性创建大量子弹会放入大量子弹到对象池中，占用大量内存
    public static Dictionary<string, int> bulletsAndCount = new Dictionary<string, int>();

    public static GameObject Get(string name)
    {
        for(int i = 0; i < bullets.Count; i++)
        {
            if(bullets[i].name==name||bullets[i].name==name + "(Clone)")
            {
                
               
                GameObject obj = bullets[i];
               
                obj.SetActive(true);
               
                bullets.RemoveAt(i);
                //Debug.Log("对象池取出："+obj.name);
                bulletsAndCount[obj.name]--;
                return obj;
            }
        }
        return null;
    }
    public static void Put(GameObject obj)
    {

        if (bulletsAndCount.ContainsKey(obj.name))
        {
            if( bulletsAndCount[obj.name] < BarrageGame.BulletPoolCount)
            {
                //如果字典中有这种子弹，且数量低于上限,子弹数加1
                bulletsAndCount[obj.name]++;

                bullets.Add(obj);

            }
            else
            {
                Destroy(obj);
            }

        }
        else
        {
            bullets.Add(obj);
            bulletsAndCount.Add(obj.name, 1);
           
        }
       

    }
}
