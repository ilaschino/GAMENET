using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    [SerializeField]
    public float speed = 6.0f;

    private Vector3 moveDirection = Vector3.zero;
 
    private void LateUpdate()
    {
        if (!isLocalPlayer) return;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;

        transform.Translate(moveDirection * Time.deltaTime);
    }
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
