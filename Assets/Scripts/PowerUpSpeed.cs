using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpSpeed : PowerUp
{
    public float speedBoost;

    public override void Apply(PowerUpManager target)
    {
        Pawn targetPawn =
            target.gameObject.GetComponent<Pawn>();

        if (targetPawn != null)
        {
            targetPawn.moveSpeed += speedBoost;
        }
    }

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
