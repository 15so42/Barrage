using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUtil 
{
    public static IWeapon CreateWeapon(string weaponName)
    {

        IWeapon weapon = (IWeapon)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(weaponName, false);
        return weapon;
    }
}
