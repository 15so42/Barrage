using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageUtil : MonoBehaviour
{
    public static T RandomFecthFromList<T>(List<T> list)
    {
        int random = Random.Range(0, list.Count);
        return list[random];
    }
}
