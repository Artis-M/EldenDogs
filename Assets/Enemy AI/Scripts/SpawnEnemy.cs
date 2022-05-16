using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        int randomCount = Random.Range(1, 3);
        for (int i = 0; i < randomCount; i++)
        {
            int randomSpawner =  Random.Range(1, 4);
            Instantiate(enemy, new Vector3(this.transform.GetChild(randomSpawner).transform.position.x, this.transform.GetChild(randomSpawner).transform.position.y + 5, this.transform.GetChild(randomSpawner).transform.position.z), Quaternion.identity);
  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
