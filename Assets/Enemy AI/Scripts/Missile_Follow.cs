using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Follow : MonoBehaviour
{

    private Vector3 player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform.position;
        Invoke("deleteMissile", 5f);  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = 
            Vector3.MoveTowards
            (transform.position, player, 
                20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            deleteMissile();  
        }

    }
    
    void deleteMissile()
    {
        Destroy(gameObject);
    }
}
