using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrackManager : MonoBehaviour
{

    private Vector2 pos;

    [SerializeField] private GameObject trackPrefab;
    [SerializeField] private Transform trackFolder;

    List<Transform> track = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTail", 0.2f, 0.2f);
    }

    void UpdateTail(){
        
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

    void IncreaseTail(){
        // Load Prefab into the world
        GameObject trackPart = (GameObject)Instantiate(trackPrefab, pos, Quaternion.identity);
        trackPart.transform.SetParent(trackFolder);
        // Keep track of it in our tail list
        track.Insert(0, trackPart.transform);
    }
}
