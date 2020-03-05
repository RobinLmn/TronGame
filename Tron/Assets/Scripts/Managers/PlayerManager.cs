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
    [SerializeField] private GameObject menu;

    static private bool endGame = false;
    private int toAdd;
    private bool addTrack = true;
    private bool addBon = false;

    void Start()
    {
        InvokeRepeating("Score", 0.1f, 0.1f);
    }

    void FixedUpdate()
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
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        endGame = false;
        score = 0;
        menu.SetActive(false);
    }

    public void AddTrack()
    {
        addTrack = true;
    }

    public void AddBonus()
    {
        addBon = true;
    }

    public void DeTrack()
    {
        addTrack = false;
    }

    public void Score()
    {
        if (addTrack){

            if (addBon)
            {
                score *= 2;
                addBon = false;
            }
            else
            {
                score += 1;
            }
        }
        else if (!addTrack && addBon)
        {
            score *=2 ;
        }
    }

    public void Continue(){
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        CancelInvoke();
        Time.timeScale = 1f;
        endGame = false;
        score = 0;
        menu.SetActive(false);
    }
}
