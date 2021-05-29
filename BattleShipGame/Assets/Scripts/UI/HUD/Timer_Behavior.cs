using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer_Behavior : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;

    float currentTime;
    float minutes;
    int seconds;
    bool canTimer = true;

    void Start()
    {
        minutes = GameMode.minutesTimer;
        seconds = GameMode.secondsTimer;
        currentTime = minutes * 60 + seconds;
    }

    
    void Update()
    {
        if (canTimer)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                MapManager.byTime = true;
                canTimer = false;
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerTxt.text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
    }
}
