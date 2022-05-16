using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightNewGame : MonoBehaviour
{
    public Light sceneLight;
    // Start is called before the first frame update
    void Start()
    {
        sceneLight.intensity = PlayerPrefs.GetFloat("brightnessValue");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
