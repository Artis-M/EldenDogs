using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDoesStuff : MonoBehaviour
{
    public GameObject player;
    private UnityEngine.Camera camera;
    public GameObject sword_light;
    public AudioSource sword_woosh;
    private bool isSpinning;
    private GameObject swordObject;

    private Animator _animator;

    private SphereCollider sphereColliderSword;
    //private float sphereRadius;
    //private float maxDistance;     //Sphere around player, if animation plays and enemy is in sphere, deal dmg
    //private LayerMask _layerMask;

    public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        swordObject = player.transform.GetChild(1).transform.GetChild(0).transform.GetChild(5).transform.GetChild(0).gameObject;
        isSpinning = false;
        camera = Camera.main;
        _animator = player.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        sphereColliderSword =
            player.transform.Find("root").Find("pelvis").Find("Weapon").Find("Sword").gameObject.GetComponent<SphereCollider>();
        sphereColliderSword.enabled = false;
        sword_light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        Ray mousePos = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePos, out hit, 100f))
        {
            Vector3 playerLook = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Vector3 targetDirection = playerLook - player.transform.position;
            float singleStep = 10 * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(player.transform.forward, targetDirection, singleStep, 0.0f);
            newDirection.y = 0;
            Quaternion lookAngle = Quaternion.LookRotation(newDirection);
            if (!isSpinning)
            {
                player.transform.rotation = lookAngle;
            }
            

        }

        if (Input.GetMouseButtonDown(0) & !_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02"))
        {
            swordObject.transform.tag = "PlayerWeapon";
            _animator.SetTrigger("Attack");
            sphereColliderSword.enabled = true;
            sword_woosh.Play();
            sword_light.SetActive(true);
            Invoke("deactivateSword", 1);
        }
        if (Input.GetMouseButton(1) & !_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02"))
        {
            swordObject.transform.tag = "PlayerWeaponSpin";
            isSpinning = true;
            sword_light.SetActive(true);
            player.transform.RotateAround(player.transform.position, player.transform.up, Time.deltaTime * 700);
            _animator.SetBool("isSpinning", true);
            sphereColliderSword.enabled = true;
           sword_woosh.Play();
      
        }

        if (Input.GetMouseButtonUp(1))
        {
            _animator.SetBool("isSpinning", false);
            isSpinning = false;
            sword_light.SetActive(false);
            sphereColliderSword.enabled = false; 
        }

    }

    void deactivateSword()
    {
        sword_light.SetActive(false);
        sphereColliderSword.enabled = false; 
    }
    
}

