using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletSpawner : NetworkBehaviour {

    public GameObject Ball;
    public Transform SpawnPoint;

    [SerializeField]
    private Transform[] ArraySpawnPoints;
    [SerializeField]
    private float spawnInterval = 3;
    [SerializeField]
    private float magnitude = 3f;


	// Use this for initialization
	void Start () {

        if(isServer)
            StartCoroutine(BallSpawn(spawnInterval));
    }

    
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator BallSpawn(float p_interval)
    {
        int randomNumber = Random.Range(0, 4);

        GameObject ball = Instantiate(Ball, ArraySpawnPoints[randomNumber].position, ArraySpawnPoints[randomNumber].rotation);
        Rigidbody force = ball.GetComponent<Rigidbody>();

        force.AddForce(ArraySpawnPoints[randomNumber].forward * magnitude);

        
        NetworkServer.Spawn(ball);

        yield return new WaitForSeconds(p_interval);

        StartCoroutine(BallSpawn(p_interval));
    }
}
