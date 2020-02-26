using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour
{
    
    // Fields
    
    // limits of the spawning area
    [SerializeField] private float minXSpawn = -19f;
    [SerializeField] private float maxXSpawn = 19f;

    [SerializeField] private float minYSpawn = -26f;
    [SerializeField] private float maxYSpawn = 26f;

    public static bool isInstantiate = false;

    // Object to spawn
    [SerializeField] public GameObject item;


    public Vector2 getRandomSpawnLocation(){
        float xSpawnPos = Random.Range(minXSpawn, maxXSpawn);
        float ySpawnPos = Random.Range(minYSpawn, maxYSpawn);

        Vector2 spawnLocation = new Vector2(xSpawnPos, ySpawnPos);

        return spawnLocation;
    }

    public GameObject SpawnCollectable(Vector2 spawnLocation, GameObject go){
        isInstantiate = true;
        GameObject clone = Instantiate(go, spawnLocation, Quaternion.identity);
        return clone;
    }

    public virtual void Spawn(){
        if (!isInstantiate){
            Vector2 spawnLocation = getRandomSpawnLocation();
            SpawnCollectable(spawnLocation, item);
        }
    }
}
