using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.volume = 0.3f;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Debug.Log("Launching Game");
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
    
}