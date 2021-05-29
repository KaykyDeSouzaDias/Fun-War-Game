using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class E_SpawnT_SliderTxt : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI txtValue;

    void Start()
    {
        //Show the seconds as a text in main menu
        slider.onValueChanged.AddListener((v) =>
        {
            txtValue.text = v.ToString("00");
        });
    }
}
