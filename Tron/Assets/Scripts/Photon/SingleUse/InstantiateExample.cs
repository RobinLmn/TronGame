using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateExample : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    private void Awake()
    {
        MasterManager.NetworkInstantiate(_prefab, transform.position, Quaternion.identity);
    }
}
