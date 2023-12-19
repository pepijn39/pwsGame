using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject pickupEffect;
    public StarTracker tracker;

    private void Start()
    {
        tracker = GameObject.Find("Player (Finite State Machine)").GetComponent<StarTracker>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            Pickup();
            tracker.StarCounter();
           


        }
    }

    private void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
       


        Destroy(gameObject);
    }
}
