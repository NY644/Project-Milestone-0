using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }

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

    public void TakeDamage(float amount, Pawn owner)
    {
        currentHealth = currentHealth - amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
