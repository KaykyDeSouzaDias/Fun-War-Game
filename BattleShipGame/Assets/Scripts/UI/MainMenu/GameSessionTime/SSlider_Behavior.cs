using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SSlider_Behavior : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI txtValue;

    float v02;

    void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            txtValue.text = v.ToString("00");
            GameMode.secondsTimer = (int)v;
        });
    }

    void Update()
    {
        //This is not to exceed the 3 minutes' limit
        if (GameMode.minuteTxt == 3)
        {
            v02 = 0;
            txtValue.text = v02.ToString("00");
            GameMode.secondsTimer = (int)v02;
        }
    }
}
