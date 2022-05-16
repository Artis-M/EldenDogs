using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnItems : MonoBehaviour
{
    
   
   public string spawnPointTag = "ItemToCollect";

   public bool alwaysSpawn = true;

   public List<GameObject> prefabsToSpawn;
   private List<int> used = new List<int>();
   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            
                int randomSpawnItem = Random.Range(0, 2);
                int randomSpawnPlace = Random.Range(0, 6);
                Debug.Log("ITEM:" + randomSpawnItem);
                if (!used.Contains(randomSpawnPlace))
                {
                Instantiate(prefabsToSpawn[randomSpawnItem],
                    new Vector3(this.transform.GetChild(randomSpawnPlace).transform.position.x,
                        this.transform.GetChild(randomSpawnPlace).transform.position.y,
                        this.transform.GetChild(randomSpawnPlace).transform.position.z), Quaternion.identity);
                used.Add(randomSpawnPlace);
            }
             
        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
    }
}
