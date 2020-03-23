using ExitGames.Client.Photon;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CustomDataType : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private MyCustomSerialization _customSerialization = new MyCustomSerialization();
    [SerializeField]
    private bool _sendAsTyped = true;

    private void Start()
    {
        PhotonPeer.RegisterType(typeof(MyCustomSerialization), (byte)'M', MyCustomSerialization.Serialize, MyCustomSerialization.Deserialize);
    }

    private void Update()
    {
        if (_customSerialization.MyNumber != -1)
        {
            SendCustomSerialization(_customSerialization, _sendAsTyped);
            _customSerialization.MyNumber = -1;
            _customSerialization.MyString = string.Empty;
        }
    }

    /// <summary>
    /// Sends an instance of MyCustomSerialization.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="typed"></param>
    private void SendCustomSerialization(MyCustomSerialization data, bool typed)
    {
        if (!typed)
            base.photonView.RPC("RPC_ReceiveMyCustomSerialization", RpcTarget.AllViaServer, MyCustomSerialization.Serialize(_customSerialization));
        else
            base.photonView.RPC("RPC_TypedReceiveMyCustomSerialization", RpcTarget.AllViaServer, _customSerialization);
    }

    /// <summary>
    /// Receives MyCustomSerialization as a byte array.
    /// </summary>
    /// <param name="datas"></param>
    [PunRPC]
    private void RPC_ReceiveMyCustomSerialization(byte[] datas)
    {
        MyCustomSerialization result = (MyCustomSerialization)MyCustomSerialization.Deserialize(datas);
        print("Received byte array: " + result.MyNumber + ", " + result.MyString);
    }

    /// <summary>
    /// Receives MyCustomSerialization as a type.
    /// </summary>
    /// <param name="datas"></param>
    [PunRPC]
    private void RPC_TypedReceiveMyCustomSerialization(MyCustomSerialization datas)
    {
        print("Received typed: " + datas.MyNumber + ", " + datas.MyString);
    }


}
