using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
}


public class Health : IDamageable
{
    // Health
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;

    public Health()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void MaxHeal()
    {
        currentHealth = maxHealth;
    }

    public void InstaKill(){

    }

    public void Heal(float healAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);
    }

    /* public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }
     */

}
