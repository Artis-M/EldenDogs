using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private List<GameObject> mapPrefabLocations = new List<GameObject>();
    public GameObject[] preFabList;
    public float tileSizeSetting;
    public GameObject playerCharacter;
    private int sphereRadius = 20;

    // Start is called before the first frame update
    void Start()
    {
        mapPrefabLocations = GameObject.FindGameObjectsWithTag("MapTile").ToList();
    }
    
    void Update()
    {
        {
            Vector3 playerCharacterLocation = playerCharacter.transform.position;
            foreach (var tileLocation in mapPrefabLocations.ToList())
            {
              
                if (Vector3.Distance(tileLocation.transform.position, playerCharacterLocation) < tileSizeSetting + 20)
                {
                    // Check X+
                    if (!Physics.CheckSphere(  new Vector3(
                        tileLocation.transform.position.x + tileSizeSetting,
                        0,
                        tileLocation.transform.position.z)
                        , sphereRadius))
                    {
                        GameObject mapPrefab = Instantiate(preFabList[Random.Range(0, preFabList.Length)],
                            new Vector3(tileLocation.transform.position.x + tileSizeSetting, 0, tileLocation.transform.position.z),
                            Quaternion.identity);
               
                        mapPrefabLocations.Add(mapPrefab);
                    }
                    // Check X-
                    if (!Physics.CheckSphere(new Vector3(
                        tileLocation.transform.position.x - tileSizeSetting,
                        0,
                        tileLocation.transform.position.z),
                        sphereRadius))
                    {
                        GameObject mapPrefab = Instantiate(preFabList[Random.Range(0, preFabList.Length)],
                            new Vector3(
                                tileLocation.transform.position.x - tileSizeSetting, 
                                0, 
                                tileLocation.transform.position.z),
                            Quaternion.identity);
               
                        mapPrefabLocations.Add(mapPrefab);
                    }
                    // Check Z+
                    if (!Physics.CheckSphere(new Vector3(
                        tileLocation.transform.position.x,
                        0,
                        tileLocation.transform.position.z + tileSizeSetting)
                        , sphereRadius))
                    {
                        GameObject mapPrefab = Instantiate(preFabList[Random.Range(0, preFabList.Length)],
                            new Vector3(tileLocation.transform.position.x, 0, tileLocation.transform.position.z + tileSizeSetting),
                            Quaternion.identity);
              
                        mapPrefabLocations.Add(mapPrefab);
                    }
                    // Check Z-
                    if (!Physics.CheckSphere(new Vector3(
                        tileLocation.transform.position.x,
                        0,
                        tileLocation.transform.position.z - tileSizeSetting), sphereRadius))
                    {
                        GameObject mapPrefab = Instantiate(preFabList[Random.Range(0, preFabList.Length)],
                            new Vector3(tileLocation.transform.position.x, 0, tileLocation.transform.position.z - tileSizeSetting),
                            Quaternion.identity);
                   
                        mapPrefabLocations.Add(mapPrefab);
                    }

                }
                else if (Vector3.Distance(tileLocation.transform.position, playerCharacterLocation) >
                         tileSizeSetting + 500)
                {
                    mapPrefabLocations.Remove(tileLocation);
                    Destroy(tileLocation);
                }
            }
        }
    }
//Very broken oh god 
    Quaternion RotatePreFab()
    {
        Quaternion quaternion = new Quaternion();
        switch (Random.Range(1, 4))
        {
            case 1:
                quaternion = new Quaternion(0, 0, 0, 0);
                break;
            case 2:
                quaternion =  new Quaternion (0, -90, 0, 0);
                break;
            case 3:
                quaternion =  new Quaternion (0, 90, 0, 0);
                break;
            case 4:
                quaternion =  new Quaternion (0, 180, 0, 0);
                break;
        }

        return quaternion;
    }
}