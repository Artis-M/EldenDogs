using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonAnimationController : MonoBehaviour
{
    private Animator skeletonAnimator;
    public AudioSource audio;
    private Rigidbody skeletonRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimator = GetComponent<Animator>();
        skeletonRigidbody = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") & !skeletonAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            skeletonAnimator.SetTrigger("Attacking");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (skeletonRigidbody.velocity.magnitude > 0.2)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            skeletonAnimator.SetBool("isRunning", true);
        }
        else
        {
            audio.Stop();
            skeletonAnimator.SetBool("isRunning", false);
        }
    }
    
}
