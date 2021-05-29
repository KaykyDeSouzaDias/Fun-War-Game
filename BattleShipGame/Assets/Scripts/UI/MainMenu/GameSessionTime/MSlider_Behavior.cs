using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MSlider_Behavior : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI txtValue;
    
    void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            txtValue.text = v.ToString("00");
            GameMode.minuteTxt = v; 
            GameMode.minutesTimer = v;
        });
    }
}
