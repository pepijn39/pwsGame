using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public PlayerHealth health;

    private void Start()
    {
        health = GameObject.Find("Player (Finite State Machine)").GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player") )
        {
            health.TakeDamage(1000);
        }
    }
}
