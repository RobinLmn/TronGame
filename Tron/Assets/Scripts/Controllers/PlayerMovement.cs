using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 dir;

    [SerializeField] private Vector2 startPos = Vector2.up;
    [SerializeField] private int playerID;
    [SerializeField] private float moveRate = 0.2f;

    void Start()
    {
        dir = startPos;
        // Call Move() every 300ms
        InvokeRepeating("Move", moveRate, moveRate);
    }

    void Update()
    {
        if (playerID == 1){
            inputControlsPlayer1();
        }
        else if (playerID == 2){
            inputControlsPlayer2();
        }
    }

    void Move()
    {
        transform.Translate(dir);
    }

    void inputControlsPlayer1(){
        // Check Input, and prevent player for going back into previous direction
        if (Input.GetKey(KeyCode.RightArrow) && dir != (-Vector2.right) )
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow) && dir != (Vector2.up) )
            dir = -Vector2.up; 
        else if (Input.GetKey(KeyCode.LeftArrow) && dir != (Vector2.right))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow) && dir != (-Vector2.up))
            dir = Vector2.up;
    }

    void inputControlsPlayer2(){
        // Check Input, and prevent player for going back into previous direction
        if (Input.GetKey(KeyCode.D) && dir != (-Vector2.right) )
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.S) && dir != (Vector2.up) )
            dir = -Vector2.up; 
        else if (Input.GetKey(KeyCode.A) && dir != (Vector2.right))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.W) && dir != (-Vector2.up))
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
        moveRate = 0.2f;
        InvokeRepeating("Move", moveRate, moveRate);
    }
}
