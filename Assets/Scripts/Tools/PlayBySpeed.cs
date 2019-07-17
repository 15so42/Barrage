using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBySpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale += 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale -= 1;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<IPlayer>().status.hp += 10000;
        }
    }
}
