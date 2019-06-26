using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatus
{
    public int hp=3;
    public int MaxHp=3;
    public int mp=3;
    public int MaxMp=3;

    public void GetDamage(int damge)
    {
        hp -= damge;

    }

    public void CostMp(int cost)
    {
        mp -= cost;
    }
   
}
