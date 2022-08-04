using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpSpeed : PowerUp
{
    public float speedBoost;

    // Apply the speed boost to the colliding target.
    public override void Apply(PowerUpManager target)
    {
        Pawn targetPawn =
            target.gameObject.GetComponent<Pawn>();

        // If it's possible, speed up the the colliding target.
        if (targetPawn != null)
        {
            targetPawn.moveSpeed += speedBoost;
        }
    }

    // When the duration of the speed up is ended
    // remove the speed boost.
    public override void Remove(PowerUpManager target)
    {
        Pawn targetPawn = 
            target.gameObject.GetComponent<Pawn>();

        if (targetPawn)
        {
            targetPawn.moveSpeed -= speedBoost;
        }
    }

    
}
