using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_UI : MonoBehaviour
{
    public AudioClip goGame, backMenu;
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
                audioSrc.PlayOneShot(goGame);
                break;
            case "back":
                audioSrc.PlayOneShot(backMenu);
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
