using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_BT : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Map01");
    }
}
