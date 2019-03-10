using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TitanGel")]
public class TitanGel : PowerUpBase {

    public float scaleUp;

    public override TimedPowerup InitializePowerup(GameObject obj)
    {
        return new TimedTitanGel(duration, this, obj);
    }
}
