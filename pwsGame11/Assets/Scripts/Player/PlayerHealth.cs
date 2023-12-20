using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    Vector2 startPos;
    public Animator anim;

    
    public Healthbar healthBar;

    void Start()
    {
        //start health and reset healthbar to full
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        startPos = new Vector2(-13, 1f);
        transform.position = startPos;
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
        
        
    }

    void Update()
    {
    
    }

   public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("takingDamage");

        
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

    public void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);

    }

  

  


    /*  private void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyCompenent))
          {
              enemyCompenent.TakeDamage(20f);
          }
      }
    */
}
