using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PushController : NetworkBehaviour {

    [SerializeField] private KeyCode push;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask ballMask;

    private void Update()
    {
        if(Input.GetKeyDown(push) && isLocalPlayer)
        {
            Collider[] Balls = Physics.OverlapSphere(transform.position, radius,ballMask);

            foreach(Collider ball in Balls)
            {
                ball.GetComponent<BallMovement>().RpcPush(transform.forward);
            }
        }
    }
}
