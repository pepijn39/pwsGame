using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    Vector2 startPos;

    public Healthbar healthBar;

    void Start()
    {
        //start health and reset healthbar to full
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        startPos = new Vector2(-13, 0.5f);
        transform.position = startPos;
    }

    void Update()
    {
    
    }

   public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            Respawn();
            currentHealth = maxHealth; healthBar.SetMaxHealth(maxHealth);
        }

        void Respawn()
        {
            transform.position = startPos;
        }

        //after taking damage update healthbar to currenthealth
        healthBar.SetHealth(currentHealth);
    }

}
