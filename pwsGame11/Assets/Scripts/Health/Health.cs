using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;


    private void Awake()
    {
        //check how much health player has
        currentHealth = startingHealth; 
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
       
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");

        }
        else
        {
            anim.SetTrigger("dead");
        }

    }
    
    
}
