using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedTitanGel : TimedPowerup
{

    public TitanGel titanGelPowerup;

    private GameObject receiver;

    public TimedTitanGel(float duration, PowerUpBase powerup, GameObject obj) : base(duration, powerup, obj)
    {
        receiver = obj;
        titanGelPowerup = (TitanGel)powerup;
    }

    public override void Activate()
    {
        TitanGel titanGelPowerup = (TitanGel)powerup;
        receiver.transform.localScale += new Vector3(titanGelPowerup.scaleUp,0,0);
        
    }

    public override void End()
    {
        receiver.transform.localScale -= new Vector3(titanGelPowerup.scaleUp, 0, 0);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PowerupReceiver>().AddPowerup(titanGelPowerup.InitializePowerup(other.gameObject));
            Destroy(gameObject);
        }
    }
}
