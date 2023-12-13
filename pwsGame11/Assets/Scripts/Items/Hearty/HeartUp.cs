using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public Animator anim;
    public PlayerHealth health;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            health.Heal(20);
            Pickup();
        }
    }


    public void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }
        
}
