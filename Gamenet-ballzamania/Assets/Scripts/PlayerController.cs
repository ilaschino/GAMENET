using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


/**
 * Use NetworkBehaviour instead of MonoBehaviour
 * to provide network identity to local player
 */
public class PlayerController : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

	// Update is called once per frame
	void Update () {

        // isLocalPlayer is determined by NetworkBehavior
        if (!isLocalPlayer) return;

        float y = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, y, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
	}


    /**
     * Command methods can only be called
     * by the local player.
     * 
     * Command methods are local player's
     * instructions to run over the server.
     * 
     * Must have the "Cmd" prefix
     */ 
    [Command]
    void CmdFire()
    {
        //Create the bullet from the prefab
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, 
            bulletSpawn.position, 
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;

        //Spawn the bullet on the server
        NetworkServer.Spawn(bullet);

        
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);

    }

    /**
     * Executed once local player is started/created over the server
     */ 
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
