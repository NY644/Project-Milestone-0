using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpScore : PowerUp
{
    public int scoreToApply;

    public override void Apply(PowerUpManager target)
    {
        GameObject targetObject = target.gameObject;
        Pawn targetScore = targetObject.GetComponent<Pawn>();

        if (targetScore != null)
        {
            if (targetScore.controller != null)
            {
                targetScore.controller.AddToScore(scoreToApply);
            }
        }
    }

    public override void Remove(PowerUpManager target)
    {
        // Do nothing
    }

}
