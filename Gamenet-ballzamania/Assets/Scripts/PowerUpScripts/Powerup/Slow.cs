using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Slow")]
public class Slow : PowerUpBase {

    public float slowValue;

    public override TimedPowerup InitializePowerup(GameObject obj)
    {
        return new TimedSlow(duration, this, obj);
    }
}
