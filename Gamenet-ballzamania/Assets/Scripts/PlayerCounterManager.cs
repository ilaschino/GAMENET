 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCounterManager : NetworkBehaviour {

    private int numberPlayerConnected { get { return NetworkManager.singleton.numPlayers; } }

    private void Awake()
    {
        if (!isServer)
            this.enabled = false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
