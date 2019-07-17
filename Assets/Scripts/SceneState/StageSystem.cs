using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem:IGameSystem
{
    public string levelName="";
    public int level = 1;

    public StageSystem(BarrageGame PBDGame) : base(PBDGame)
    {
   
       
    }
}
