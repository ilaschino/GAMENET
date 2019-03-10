using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedPowerup : MonoBehaviour {
    protected float duration;
    protected PowerUpBase powerup;
    protected GameObject obj;

    public abstract void Activate();
    public abstract void End();

    public bool IsFinished
    {
        get { return duration <= 0 ? true : false; }
    }


    public TimedPowerup(float duration, PowerUpBase powerup, GameObject obj)
    {
        this.duration = duration;
        this.powerup = powerup;
        this.obj = obj;
    }

    public void Tick(float delta)
    {
        Debug.Log("DURATION: " + duration);
        duration -= delta;
        if (duration < 0) End();
    }
}
