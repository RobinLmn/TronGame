using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TronAI : MonoBehaviour
{

    [SerializeField] private PlayerMovement playerM;
    [SerializeField] private GameObject player;

    void Update()
    {

        Vector3 playerDir = playerM.getDirection().normalized;

        if (playerDir == Vector3.right)
        {
            if (this.transform.position.x >= ( player.transform.position.x + 2))
            {
                // MOVE PLAYER 
            }
        } 
    }

}
