using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    void Start()
    {
        GameMode.spawnRate = 1f;

        //Start the game with 1 minute left if the player change nothing
        GameMode.minutesTimer = 1;
        GameMode.secondsTimer = 0;
    }

    public void LoadSpawnT(float spawn)
    {
        GameMode.spawnRate = spawn;
    }
}
