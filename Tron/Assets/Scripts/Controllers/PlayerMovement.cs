using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 dir;

    [SerializeField] private Vector2 startPos = Vector2.up;
    [SerializeField] private int playerID;
    [SerializeField] private float moveRate = 0.1f;
    [SerializeField] private GameObject menu;

    
    [SerializeField] private InputManager inputManager;

        private KeyCode right;
        private KeyCode left; 
        private KeyCode up;
        private KeyCode down;
        private KeyCode pause;
    
    private InputManager.PlayerInput player;

    void Start()
    {
        dir = startPos;
        // Call Move() every 300ms
        InvokeRepeating("Move", moveRate, moveRate);

        if (playerID == 1){
            player = inputManager.players[0];
        }
        else if (playerID == 2){
            player = inputManager.players[1];
        }

    }

    void Update()
    {

        if (Input.GetKeyDown(player.pause))
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
        }

        inputControlsPlayer();

    }

    void Move()
    {
        transform.Translate(dir);
    }

    void inputControlsPlayer(){
        // Check Input, and prevent player for going back into previous direction
        if (Input.GetKey(player.right) && dir != (-Vector2.right) )
            dir = Vector2.right;
        else if (Input.GetKey(player.down) && dir != (Vector2.up) )
            dir = -Vector2.up; 
        else if (Input.GetKey(player.left) && dir != (Vector2.right))
            dir = -Vector2.right;
        else if (Input.GetKey(player.up) && dir != (-Vector2.up))
            dir = Vector2.up;
    }

    public void doubleSpeed()
    {
        CancelInvoke("Move");
        moveRate *= 1/2f;
        InvokeRepeating("Move", moveRate, moveRate);
    }

    public void resetSpeed()
    {
        CancelInvoke("Move");
        moveRate = 0.1f;
        InvokeRepeating("Move", moveRate, moveRate);
    }

    public Vector3 getDirection()
    {
        return dir;
    }
}
