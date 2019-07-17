using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    public Image[] hearts;

    private void OnEnable()
    {
        Action<ArrayList> action = new Action<ArrayList>(HpChanged);
        EventManager.StartListening("playerBeDamaged", action);

        
    }

    void HpChanged(ArrayList param)
    {
        int hp = (int)param[0];
       
     
        for(int i = 0; i < hearts.Length; i++)
        {
            if (i > hp-1)
                hearts[i].enabled = false;
            else
                hearts[i].enabled = true;
        }

    }

    private void OnDestroy()
    {
        EventManager.StopListening("playerBeDamaged");
    }

  

}
