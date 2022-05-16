using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsMenu;
 //   public GameObject movesMenu;
    public GameObject pauseMenu;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
  
    }
    // public void BackToPauseManu()
    // {
    //     Time.timeScale = 0;
    //     pauseMenu.SetActive(true);
    //     movesMenu.SetActive(false);
    // }
    //
    // public void MovesMenu()
    // {
    //     Time.timeScale = 0;
    //     pauseMenu.SetActive(false);
    //     movesMenu.SetActive(true);
    //
    // }


    public void ResumeGame ()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainLevel");
    }
    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene"); 
    }
    public void SettingsButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
