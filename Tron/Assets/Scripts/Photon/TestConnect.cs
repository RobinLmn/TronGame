using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting");
        PhotonNetwork.GameVersion = "0.01";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
    }

}
