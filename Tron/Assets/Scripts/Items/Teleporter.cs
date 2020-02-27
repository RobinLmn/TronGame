using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : AbstractInteractable
{
    static private GameObject teleporter1;
    static private GameObject teleporter2;
    
    void OnTriggerEnter(Collider other){
        
        if (other.gameObject.CompareTag("Teleporter1")){
            ActiveItem(teleporter2);
            PickUp();
        }
        else if (other.gameObject.CompareTag("Teleporter2")){
            ActiveItem(teleporter1);
            PickUp();        
        }

    }

    public void ActiveItem(GameObject go){
        transform.position = go.transform.position;
    }

    public override void Spawn(){
        
        // Spawn the two teleporters

        if (!isInstantiate){
            Vector2 spawnLocation1 = getRandomSpawnLocation();
            teleporter1 = SpawnCollectable(spawnLocation1, item);
            teleporter1.tag = "Teleporter1";

            Vector2 spawnLocation2 = getRandomSpawnLocation();
            teleporter2 = SpawnCollectable(spawnLocation2, item);
            teleporter2.tag = "Teleporter2";
        }


    }

    void Start(){
        InvokeRepeating("Spawn", 2f, 2f);
    }

    void PickUp(){
        teleporter1.SetActive(false);
        teleporter2.SetActive(false);
        isInstantiate = false;
    }
}
