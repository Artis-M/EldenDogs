using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField]
    Slider volumeSlider;

    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", -33);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        audioMixer.SetFloat("MusicVolumeParameter", volumeSlider.value);
        Save();
    }
    public void Load()
    {
       volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
       ChangeVolume();
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
