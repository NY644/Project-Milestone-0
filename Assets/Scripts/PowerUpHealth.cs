using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUpHealth : PowerUp
{
    public float healthToApply;
    

    public override void Apply(PowerUpManager target)
    {
        GameObject targetObject = target.gameObject;
        Health targetHealth = targetObject.GetComponent<Health>();


        if (targetHealth != null)
        {
            targetHealth.Heal(healthToApply);

        }
    }

    public override void Remove(PowerUpManager target)
    {
        // Do nothing
    }
}
