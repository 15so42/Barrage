using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootAble 
{
    
    GameObject BulletPrefab { get; set; }
    string BulletName { get; set; }
    GameObject Obj { get; set; }
}
