using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkManagerDebug : MonoBehaviour
{
    private NetworkManager networkManager;
    // Start is called before the first frame update
    void Start()
    {
        networkManager = gameObject.GetComponent<NetworkManager>();
        networkManager.StartHost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
