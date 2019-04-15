using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraFollowPlayer : NetworkBehaviour {

    [SerializeField] private Vector3 offset;
    [HideInInspector]public GameObject localPlayer;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(fixRotation());
    }

    private void Update()
    {
        if (localPlayer == null)
            return;

        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, localPlayer.transform.position.x, 5 * Time.deltaTime);
        transform.position = pos;
    }

    IEnumerator fixRotation()
    {
        yield return new WaitUntil(() => GameObject.Find("Local") != null);
        localPlayer = GameObject.Find("Local");

        Vector3 back = -localPlayer.transform.forward;
        offset.z *= back.z;

        transform.position = localPlayer.transform.position + offset;

        transform.LookAt(SimpleSceneData.singleton.centerStage.transform);
    }


    public void ResetPosition()
    {
        StartCoroutine(fixRotation());
    }
}
