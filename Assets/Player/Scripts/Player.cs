using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameOver gameOver;
    public float health =10;
    public Text coinsText;
    public Text item1Text;
    public AudioSource audio;
    public AudioClip hitSound;
    private int coinsCount;
    private int item1Counter;
    public ItemsToCollect itemToCollect;
    public GameObject itemToCollect1go;
    private Animator _animator;

    private float hitLast = 0;
    private float delay = 1; //seconds 
    
    

    // Start is called before the first frame update
    void Start()
    {
        coinsCount = 0;
        item1Counter = 0;
        // item2Counter = 0;
        // item3Counter = 0;
        coinsText.text = "0000";
        _animator = GetComponent<Animator>();

    }
    void Update()
    {
        //equipped items
        //health logic
        if(Input.GetKeyDown(KeyCode.H) && item1Counter >= 1 && health < 10)
        {
                item1Counter -= 1;
                health += 1;
                item1Text.text = item1Counter.ToString();
           
            if (item1Counter < 1)
            {
                item1Text.GameObject().SetActive(false);
                itemToCollect1go.SetActive(false);
            }

        }

    }

  
    void OnTriggerEnter(Collider other) 
    {
      // Collect items
        if (other.gameObject.CompareTag ("ItemToCollect"))
        {
            other.gameObject.SetActive (false);
            itemToCollect.Setup();
            item1Counter += 1;
            item1Text.GameObject().SetActive(true);
            item1Text.text = item1Counter.ToString();
            
        } 
       
        // Coins
        if (other.gameObject.CompareTag ("Coin"))
        {
            other.gameObject.SetActive (false);
            coinsCount += 1;
            coinsText.text = coinsCount.ToString();
        }

        if (other.gameObject.CompareTag("MagicMissile"))
        {
            health -= 3;
                
            audio.PlayOneShot(hitSound);
            _animator.SetTrigger("Hit");
        }
        if (other.gameObject.CompareTag("MagicMissile") && health <= 0)
        {
           
            Time.timeScale = 0;
            _animator.SetTrigger("Die");
            gameOver.Setup();
        }
        
    }
    void OnCollisionStay(Collision col)
    {
    
        if (Time.time - hitLast < delay)
            return;
        // Enemies
        if (col.gameObject.CompareTag("Enemy") && health>0)
        {
            health -= 1;
                
            audio.PlayOneShot(hitSound);
            _animator.SetTrigger("Hit");
        }

        if (col.gameObject.CompareTag("Enemy") && health <= 0)
        {
           
            Time.timeScale = 0;
            _animator.SetTrigger("Die");
            gameOver.Setup();
        }
        hitLast = Time.time;
    }
    
}
