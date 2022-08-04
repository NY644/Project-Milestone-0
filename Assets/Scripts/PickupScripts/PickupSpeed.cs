using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeed : MonoBehaviour
{
    public PowerUpSpeed powerup;



    // Function for when an object touches the Speed pickup.
    public void OnTriggerEnter(Collider other)
    {
        PowerUpManager otherPowerupManager =
            other.GetComponent<PowerUpManager>();

        // If it's possible for colliding object to pick up health,
        // pick it up and destroy health item
        if (otherPowerupManager != null)
        {
            otherPowerupManager.Apply(powerup);

            Destroy(gameObject);
        }
    }
}

