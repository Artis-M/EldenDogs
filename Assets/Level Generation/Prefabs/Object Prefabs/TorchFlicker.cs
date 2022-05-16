using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlicker : MonoBehaviour
{
    // Start is called before the first frame update
    private Light torchLight;
    public float lowLight = -4.5F;
    public float highLight = 4.5F;
    
    void Start()
    {
        torchLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        torchLight.intensity += (Random.Range(-4.5f, 4.5f)) * Time.deltaTime;
    }
}
