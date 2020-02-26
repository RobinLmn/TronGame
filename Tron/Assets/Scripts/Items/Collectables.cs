using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : AbstractInteractable
{   

    [SerializeField] private PlayerManager playerMan;
     
    void ActiveItem(){
        playerMan.increaseScore(100);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable")){

            Debug.Log("Interacted with collectable");
            ActiveItem();
            other.gameObject.SetActive(false);
            isInstantiate = false;
        }
    }

    public override void Spawn(){
        base.Spawn();
    }

    void Start(){
        InvokeRepeating("Spawn", 4f, 4f);
    }

}