
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainLevel"); 
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartSceneCopy"); 
    }
}
