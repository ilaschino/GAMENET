using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    [SerializeField]
    public float speed = 6.0f;
    public float increaseSpdOnTimeSlow;

    [SerializeField]
    public float distanceDisableInput = 5f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 initialPos = Vector3.zero;

    private float DistanceInitial { get { return Vector3.Distance(transform.position, initialPos); } }
    private float DifferenceInitial { get { return transform.position.x - initialPos.x; } }

    private void LateUpdate()
    {
        if (!isLocalPlayer) return;

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * transform.right.x, 0.0f, 0.0f);

        if (DifferenceInitial < 0 && DistanceInitial > distanceDisableInput && moveDirection.x < 0)
            return;
        else if (DifferenceInitial > 0 && DistanceInitial > distanceDisableInput && moveDirection.x > 0)
            return;

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;

        transform.Translate(moveDirection * (Time.deltaTime * increaseSpdOnTimeSlow));
    }
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.blue;
        Vector3 target = SimpleSceneData.singleton.centerStage.transform.position;
        target.y = transform.position.y;
        SimpleSceneData.singleton.centerStage.transform.position = target;
        transform.LookAt(SimpleSceneData.singleton.centerStage.transform, Vector3.up);
        initialPos = transform.position;
        gameObject.name = "Local";
    }
}
