using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private int playerID;
    [SerializeField] private int score = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        if (playerID == 1){
            Debug.Log("Player1 Lost");
        }
        else {
            
        }
        
        Time.timeScale = 0f;
    }

    public void increaseScore(int toAdd){
        this.score += toAdd;
    }
}
