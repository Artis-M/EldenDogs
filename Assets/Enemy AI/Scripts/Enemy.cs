using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject textPrefab;
    public double health;
    public AudioSource audio;
    public AudioClip hitSound;
    public AudioClip deathSound;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
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
            AudioSource.PlayClipAtPoint(deathSound,transform.position);
            Destroy(gameObject);
        }
    }
}
