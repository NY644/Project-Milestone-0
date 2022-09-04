using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScoreAdder : MonoBehaviour
{
    public PowerUpScore powerup;

    public void OnTriggerEnter(Collider other)
    {
        PowerUpManager otherPowerupManager =
           other.GetComponent<PowerUpManager>();

        // If it's possbile for colliding object to add a score
        // pickup score adder.
        if (otherPowerupManager != null)
        {
            otherPowerupManager.Apply(powerup);
            
            Destroy(gameObject);
        }
    }
}
