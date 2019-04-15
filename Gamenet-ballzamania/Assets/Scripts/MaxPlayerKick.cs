using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MaxPlayerKick : NetworkBehaviour {

    private void Awake()
    {
        if(NetworkManager.singleton.numPlayers > 2)
        {
            NetworkManager.singleton.StopClient();
        }
    }
}
