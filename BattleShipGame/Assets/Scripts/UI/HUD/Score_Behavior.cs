using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score_Behavior : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    public static int score = 0;

    private void Start()
    {
        score = 0;
        scoreTxt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreTxt.text = score.ToString("00");
    }
}
