using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : ScriptableObject {

    public float duration;

    public abstract TimedPowerup InitializePowerup(GameObject obj);
}
