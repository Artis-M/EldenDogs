using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    [SerializeField]
    Slider brightnessSlider;

    public Light sceneLight;

    // Start is called before the first frame update
    void Start()
    {
        
        
        if (!PlayerPrefs.HasKey("brightnessValue"))
        {
            PlayerPrefs.SetFloat("brightnessValue", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeBrightness()
    {
        sceneLight.intensity = brightnessSlider.value;
        Save();
    }
    private void Load()
    {
        brightnessSlider.value = PlayerPrefs.GetFloat("brightnessValue");
        sceneLight.intensity = brightnessSlider.value;
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("brightnessValue", brightnessSlider.value);
    }

    // Back buttom
    public GameObject settingsMenu;
    public GameObject pauseMenu;

    public void BackButton()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
