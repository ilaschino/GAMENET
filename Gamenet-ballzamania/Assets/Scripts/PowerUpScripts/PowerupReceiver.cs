using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupReceiver : MonoBehaviour {

    public List<TimedPowerup> currentPowerups = new List<TimedPowerup>();

    private void Update()
    {
        foreach (TimedPowerup powerup in currentPowerups.ToArray())
        {
            powerup.Tick(Time.deltaTime);
            if(powerup.IsFinished)
            {
                currentPowerups.Remove(powerup);
            }
        }
    }

    public void AddPowerup(TimedPowerup powerup)
    {
        currentPowerups.Add(powerup);
        powerup.Activate();
    }
}
