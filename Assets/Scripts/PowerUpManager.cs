using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public List<PowerUp> powerups;

    // Start is called before the first frame update
    void Start()
    {
        // Create the list of powerups
        powerups = new List<PowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        CountdownPowerups();
    }

    private void CountdownPowerups()
    {
        List<PowerUp> removalQueue = new List<PowerUp>();


        foreach (PowerUp pu in powerups)
        {
            // Subtract frame draw time from lifespan
            pu.lifespan -= Time.deltaTime;

            // If our lifespan is <0, remove the powerup
            if (pu.lifespan <= 0)
            {
                // Queue for removal
                removalQueue.Add(pu);
            }
        }

        // Now that we are done iterating,
        // remove everything in the removal queue
        foreach (PowerUp PowerupToRemove in removalQueue)
        {
            // Remove them
            Remove(PowerupToRemove);
        }
    }

    public void Apply(PowerUp powerupToApply)
    {
        // Actually apply the powerup
        powerupToApply.Apply(this);

        // If it has an invalid duration
        // (negative) then don't add it so it lasts forever
        if (powerupToApply.lifespan < 0)
        {
            // Do NOTHING!!
        }
        else
        {
            powerups.Add(powerupToApply);
        }

        // Add it to the list
        powerups.Add(powerupToApply);
    }

    public void Remove(PowerUp powerupToRemove)
    {
        // unapply the powerup
        powerupToRemove.Remove(this);

        //Remove from the list
        powerups.Remove(powerupToRemove);
    }
}
