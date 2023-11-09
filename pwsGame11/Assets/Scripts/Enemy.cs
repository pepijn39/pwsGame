using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maximumHealth = 50f;

    private void Start()
    {
        health = maximumHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerComponent))
        {
            playerComponent.TakeDamage(20);
        }
    }
}
