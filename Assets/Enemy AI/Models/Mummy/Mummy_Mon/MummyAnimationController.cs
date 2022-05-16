using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyAnimationController : MonoBehaviour
{
    private Animator mummyAnimator;

    private Rigidbody mummyRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        mummyAnimator = GetComponent<Animator>();
        mummyRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mummyRigidbody.velocity.magnitude > 0)
        {
            mummyAnimator.SetBool("isRunning", true);
        }
        else
        {
            mummyAnimator.SetBool("isRunning", false);
        }
    }
}
