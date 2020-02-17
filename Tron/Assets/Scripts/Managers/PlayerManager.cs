using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        Debug.Log("You Lost");
        // Reload App
    }
}
