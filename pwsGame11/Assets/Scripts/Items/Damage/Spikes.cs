using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerHealth health;

    private void Awake()
    {
        health = GameObject.Find("Player (Finite State Machine)").GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            health.TakeDamage(50);
        }
      
        
    }
}
