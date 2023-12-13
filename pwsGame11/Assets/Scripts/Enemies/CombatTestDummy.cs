using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummy : MonoBehaviour
{
    private Animator anim;
    public float enemyMaxHealth = 50f;
    public float enemyCurrentHealth;

    private void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;

        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



}




