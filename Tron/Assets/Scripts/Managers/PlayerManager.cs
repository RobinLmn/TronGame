using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private int playerID;
    [SerializeField] private int score = 0;
    [SerializeField] private Text winningText;
    [SerializeField] private Button replayButton;


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
            winningText.gameObject.SetActive(true);
            winningText.text = "YELLOW WON!";
        }
        else if (playerID == 2)
        {
            winningText.gameObject.SetActive(true);
            winningText.text = "BLUE WON!";
        }   
        
        replayButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void increaseScore(int toAdd){
        this.score += toAdd;
    }
}
