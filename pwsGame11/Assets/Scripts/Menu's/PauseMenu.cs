using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject healthBarUI;

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsPaused)
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
        pauseMenuUI.SetActive(false);
        healthBarUI.SetActive(true);
        Time.timeScale = 1;
        IsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        healthBarUI.SetActive(false);
        Time.timeScale = 0;
        IsPaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
}
