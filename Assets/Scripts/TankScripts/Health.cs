using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public TankPawn myPawn;

    // When the program starts,
    // the currentHealth is set to the
    // same as maxHealth
    public void Start()
    {
        currentHealth = maxHealth;
        myPawn = GetComponent<TankPawn>();
    }

    // This function allows the
    // colliding object to heal
    // by it's currentHealth +
    // the healing amount.
    public void Heal (float amount)
    {
        currentHealth = currentHealth + amount;

        currentHealth = Mathf.Min(currentHealth, maxHealth);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            // TODO: Cool stuff on overheal
        }
    }

    // When an object takes damage it will have it's
    // currentHealth - the amount of damage.
    public void TakeDamage(float amount, Pawn owner)
    {

        currentHealth = currentHealth - amount;

        // If object health is = or less than 0 health
        // the Die function is called
        if (currentHealth <= 0)
        {
            Die(owner);
        }
    }

    // When the object is = or less than 0 health
    // The object is destroyed.
    public void Die(Pawn killer)
    {
        Destroy(this.gameObject);
        if (killer != null)
        {
            killer.controller.AddToScore(myPawn.killValue);

        }
    }
}
