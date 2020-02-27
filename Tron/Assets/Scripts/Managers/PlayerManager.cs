using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private int playerID;
    [SerializeField] public int score = 1;
    [SerializeField] private Text winningText;
    [SerializeField] private Button replayButton;
    [SerializeField] private Text scoreText;
    static private bool endGame = false;

    void Update()
    {
        if (!endGame)
        {
            scoreText.text = score.ToString();
        }
    }

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
        endGame = true;
    }

    public void increaseScore(int toAdd){
        this.score += toAdd;
    }

    public void Replay()
    {
        CancelInvoke();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        endGame = false;
        score = 0;
    }
}
