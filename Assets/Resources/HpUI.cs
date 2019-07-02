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
        Action<ArrayList> action = new Action<ArrayList>(LostHp);
        EventManager.StartListening("playerBeDamaged", action);

        
    }

    void LostHp(ArrayList param)
    {
        int hp = (int)param[0];
        Debug.Log(hp);
        for(int i = hp; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }

    }

    private void OnDestroy()
    {
        EventManager.StopListening("playerBeDamaged");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
