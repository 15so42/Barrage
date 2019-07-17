using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageUtil : MonoBehaviour
{
    public static T RandomFecthFromList<T>(List<T> list)
    {
        //bool allNull=true;
        //for(int i = 0; i < list.Count; i++)
        //{
        //    if (list[i] != null)
        //        allNull = false;
        //}
        //if (allNull)
        //    return null;
        int random = Random.Range(0, list.Count);
        return list[random];
    }
}
