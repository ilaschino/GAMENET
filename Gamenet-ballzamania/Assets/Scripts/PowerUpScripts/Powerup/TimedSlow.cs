using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSlow : TimedPowerup {

    [SerializeField] private string tagCollide = "Wall";
    public Slow slowPowerup;

    private PlayerMovement playerMovement;

    public TimedSlow(float duration, PowerUpBase powerup, GameObject obj) : base(duration, powerup, obj)
    {
        playerMovement = obj.GetComponent<PlayerMovement>();
        slowPowerup = (Slow)powerup;
    }

    public override void Activate()
    {
        Slow slowPowerup = (Slow)powerup;
        playerMovement.increaseSpdOnTimeSlow += slowPowerup.slowValue;
        Time.timeScale = 0.5f;
        Debug.Log(slowPowerup.slowValue);
    }

    public override void End()
    {
        playerMovement.increaseSpdOnTimeSlow -= slowPowerup.slowValue;
        Time.timeScale = 1.0f;
        Debug.Log(slowPowerup.slowValue);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagCollide)
        {
            other.gameObject.GetComponent<PowerupReceiver>().AddPowerup(slowPowerup.InitializePowerup(other.gameObject));
            Destroy(gameObject);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.GetComponent<PowerupReceiver>().AddPowerup(slowPowerup.InitializePowerup(this.gameObject));
    //        Destroy(gameObject);
    //    }
        
    //}
}
