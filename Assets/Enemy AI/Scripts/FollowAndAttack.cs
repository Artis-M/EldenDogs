using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndAttack : MonoBehaviour
{
   

    private Transform player;

    public float followRange = 20;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()       
    {
        transform.LookAt(player.transform);

        if (Vector3.Distance(player.transform.position, transform.position) < 20)
        {
            transform.position = 
                Vector3.MoveTowards
                (transform.position, player.transform.position, 
                    2 * Time.deltaTime);
        }

    }
}
