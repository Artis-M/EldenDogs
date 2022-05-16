using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartView : MonoBehaviour
{
    public string Scene_Name;
    public void StartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Scene_Name); 
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
