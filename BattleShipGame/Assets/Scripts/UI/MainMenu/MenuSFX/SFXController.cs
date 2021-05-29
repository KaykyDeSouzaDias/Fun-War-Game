using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioClip goBtn, backBtn;
    public AudioSource audioSrc;
    
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void playSound(string clip)
    {
        switch (clip)
        {
            case "go":
                audioSrc.PlayOneShot(goBtn);
                break;
            case "back":
                audioSrc.PlayOneShot(backBtn);
                break;
        }
    }

    public void go()
    {
        playSound("go");
    }
    public void back()
    {
        playSound("back");
    }
}
