using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSceneData : MonoBehaviour {

    public GameObject centerStage;
    public GameObject YouLoseText;

    public static SimpleSceneData singleton = null;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(this.gameObject);

    }
}
