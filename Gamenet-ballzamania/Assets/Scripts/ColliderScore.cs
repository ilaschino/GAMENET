using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScore : MonoBehaviour {

    PlayerScore score;

	// Use this for initialization
	void Start () {
        score = transform.parent.GetComponent<PlayerScore>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            score.OnChangehealth(1);
        }
    }
}
