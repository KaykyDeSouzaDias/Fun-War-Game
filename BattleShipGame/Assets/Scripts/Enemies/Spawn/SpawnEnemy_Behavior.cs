using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy_Behavior : MonoBehaviour
{
    public Slider slider;
    
    void Start()
    {
        //Get the spawn rate selected by the player at main menu
        slider.onValueChanged.AddListener((v) =>
        {
            GameMode.spawnRate = v;
        });
    }
}
