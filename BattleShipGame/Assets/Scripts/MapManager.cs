using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MapManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject endMenu;

    public AudioSource audioSrc;
    public AudioClip win, lose;

    //Score and title, both are to show at End game menu
    public TextMeshProUGUI score;
    public TextMeshProUGUI title;

    public static bool isPaused = false;

    //How the game ended
    public static bool byTime = false;
    public static bool byDeath = false;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    public void Update()
    {
        if (byDeath)
        {
            StartCoroutine(waitByDeath());
        }
        if (byTime)
        {
            StartCoroutine(waitByTime());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    //Pause menu functionality
    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        audioSrc.Play();

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        audioSrc.Stop();

        Time.timeScale = 0f;
        isPaused = true;
    }

    //Return to main menu for Pause and End game menus
    public void goMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    //End game menu functionality
    public void playAgain()
    {
        endMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map01");
        byDeath = false;
        byTime = false;
    }

    void lostGame()
    {
        endMenu.SetActive(true);
        audioSrc.Stop();
        audioSrc.PlayOneShot(lose);

        Time.timeScale = 0f;
        score.text = Score_Behavior.score.ToString("00" + "points");
        title.text = "GAME OVER";
    }

    void winGame()
    {
        endMenu.SetActive(true);
        audioSrc.Stop();
        audioSrc.PlayOneShot(win);

        Time.timeScale = 0f;
        score.text = Score_Behavior.score.ToString("00" + "points");
        title.text = "CONGRATULATIONS";
    }

    //Wait to show the menu
    IEnumerator waitByDeath()
    {
        yield return new WaitForSeconds(3.5f);
        lostGame();
    }

    IEnumerator waitByTime()
    {
        yield return new WaitForSeconds(3.5f);
        winGame();
    }
}
