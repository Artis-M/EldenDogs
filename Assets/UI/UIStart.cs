using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : MonoBehaviour
{
    // Start is called before the first frame update
    public VolumeManager VolumeManagerScript;
    void Start()
    {
        VolumeManagerScript.Load();
        VolumeManagerScript.ChangeVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
