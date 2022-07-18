using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerupLandMine : PowerUp
{
    public float takeDamage;

    public override void Apply(PowerUpManager target)
    {
        // These 2 lines it to be
        // possible for the Health object
        // to work with a colliding object.
        GameObject targetObject = target.gameObject;
        Health targetHealth = targetObject.GetComponent<Health>();

        // If it's possible to give
        // health to the colliding object
        // then give it the health powerup.
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(takeDamage, null);

        }
    }

    public override void Remove(PowerUpManager target)
    {
        // Do nothing
    }
}
