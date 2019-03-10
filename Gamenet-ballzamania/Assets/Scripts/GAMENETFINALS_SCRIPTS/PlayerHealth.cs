using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour {


    public const int PlayerMaxHealth = 5;
    public Collision PlayerHealthHitBox;
    public int CurrentHealth = PlayerMaxHealth;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("dedz");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(1);
        Debug.Log("HITBOXED");
    }
}
