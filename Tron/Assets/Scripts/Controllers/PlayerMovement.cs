using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 dir;
    private Vector2 pos;

    [SerializeField] private GameObject trackPrefab;
    [SerializeField] private int playerID;
    [SerializeField] private Vector2 startPos = Vector2.up;
    [SerializeField] private Transform trackFolder;

    List<Transform> track = new List<Transform>();
    
 
    void Start()
    {
        dir = startPos;
        // Call Move() every 300ms
        InvokeRepeating("Move", 0.2f, 0.2f);
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

        pos = transform.position;

        if (track.Count > 0) {
            // Move last Tail Element to where the Head was, it will superpose with the player so ignore the collision
            track.Last().gameObject.tag = "Untagged";
            track.Last().position = pos;
            // Add to front of list, remove from the back
            track.Insert(0, track.Last());
            track.RemoveAt(track.Count-1);
        }
        if (track.Count >= 2){
            // Start to detect collision after 2 tracks
            track[1].gameObject.tag = "Track";
        }

        IncreaseTail();

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

    void IncreaseTail(){
        // Load Prefab into the world
        GameObject trackPart = (GameObject)Instantiate(trackPrefab, pos, Quaternion.identity);
        trackPart.transform.SetParent(trackFolder);
        // Keep track of it in our tail list
        track.Insert(0, trackPart.transform);
    }
}
