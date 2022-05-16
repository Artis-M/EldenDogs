using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 playerMovement = Vector3.zero;
    private float gravity = 8f; //dunno how needed is this
    private float speed = 6f;
    private Animator _animator;
    private Rigidbody body;
    private CharacterController player;

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (player.isGrounded)
        {
            playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerMovement *= speed;

            if (player.velocity.magnitude > 0)
            {
                _animator.SetBool("isRunning", true);
                if (!audio.isPlaying)
                {
                    audio.Play();
                }
            }
            else
            {
                audio.Stop();
                _animator.SetBool("isRunning", false);
            }
        }

        playerMovement.y -= gravity * Time.deltaTime; 
        player.Move(playerMovement * Time.deltaTime);
    }
}
