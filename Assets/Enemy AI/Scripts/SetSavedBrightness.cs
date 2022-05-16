using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSavedBrightness : MonoBehaviour
{

    public Light directionalLight;
    // Start is called before the first frame update
    void Start()
    {
        directionalLight.intensity = PlayerPrefs.GetFloat("brightnessValue");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
