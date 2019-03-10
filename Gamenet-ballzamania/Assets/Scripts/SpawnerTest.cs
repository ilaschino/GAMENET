using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnerTest : NetworkBehaviour {

    [SerializeField] private GameObject ballPrefab;

    private void Start()
    {
        if (isServer)
            StartCoroutine(CmdSpawn());
    }

    private void Update()
    {
        print(isServer);
    }

    // Update is called once per frame
    IEnumerator CmdSpawn()
    {
        GameObject ball = Instantiate(ballPrefab);
        NetworkServer.Spawn(ball);

        yield return new WaitForSeconds(3f);

        StartCoroutine(CmdSpawn());
    }
}
