using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBgm : MonoBehaviour
{
    public AudioClip[] clips;
    public int index = 0;
    bool playCompleted=false;

    AudioSource ad;

    private void Start()
    {
        ad = GetComponent<AudioSource>();
        ad.clip = clips[index];
        ad.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (ad.isPlaying)
        {
            
            return;
        }
        else
        {
            if (index < clips.Length - 1)
            {


                index++;
                ad.clip = clips[index];
                ad.Play();
            }
            else
            {
                index = 0;
            }

        }

    }
}
