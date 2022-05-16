using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy_Boss : MonoBehaviour
{
    private Transform player;
    
    public GameObject textPrefab;
    public double health;
    public AudioSource audio;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public AudioClip fireball_fire;
    public GameObject missile;
    private Rigidbody body;
    private float timer;
    private bool isDying;
    public int missileCooldown;
    
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isDying = false;
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
        
        if (!isDying)
        {
            int delay = Random.Range(1, 2);
            transform.LookAt(player.transform);

            if (Vector3.Distance(player.transform.position, transform.position) > 4 & Vector3.Distance(player.transform.position, transform.position) < 7)
            {
                transform.position = 
                    Vector3.MoveTowards
                    (transform.position, new Vector3(-transform.position.x, 0, -transform.position.z), 
                        5 * Time.deltaTime);
         
            }
            else if (Vector3.Distance(player.transform.position, transform.position) > 7 & Vector3.Distance(player.transform.position, transform.position) < 20  )
            {
                transform.position = 
                    Vector3.MoveTowards
                    (transform.position, new Vector3(player.transform.position.x, 0, player.transform.position.z), 
                        2 * Time.deltaTime);
            }

            if (Vector3.Distance(player.transform.position, transform.position) < 25)
            {
                timer += Time.deltaTime;
                if(timer > missileCooldown){
                    Invoke("fireMissileAnimation", delay);
                    timer = 0;
                }
            
            }

            if (body.velocity.magnitude > 0.2)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
        
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PlayerWeapon") | other.gameObject.CompareTag("PlayerWeaponSpin") && health > 0)
        {
            if (other.gameObject.CompareTag("PlayerWeapon"))
            {
                health -= 2;
            }
            else
            {
                health -= 0.5;
            }
            audio.PlayOneShot(hitSound);
            var textHeath = Instantiate(textPrefab, transform.position, Quaternion.identity, transform);
            textHeath.GetComponent<TextMesh>().text = health.ToString();
        }

        if (other.gameObject.CompareTag("PlayerWeapon") | other.gameObject.CompareTag("PlayerWeaponSpin") && health <= 0)
        {
            deathSeqeunce();
        }
    }

    void fireMissileAnimation()
    {
        animator.SetTrigger("Attack");
        Invoke("createMissile", 1);

    }

    void createMissile()
    {
        audio.PlayOneShot(fireball_fire);
        Instantiate(missile, new Vector3(transform.position.x + 2, 5, transform.position.z), Quaternion.identity);
    }

    void deathSeqeunce()
    {
        animator.SetTrigger("Dead");
        isDying = true;
        AudioSource.PlayClipAtPoint(deathSound,transform.position);
        Invoke("destroySkeleton", 8);
    }

    void destroySkeleton()
    {
        Destroy(gameObject);
    }
}
