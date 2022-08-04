using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// This allows the PowerUp to be
// picked up or removed from intended target
public abstract class PowerUp
{
    public float lifespan;
    public abstract void Apply(PowerUpManager target);
    public abstract void Remove(PowerUpManager target);
}
