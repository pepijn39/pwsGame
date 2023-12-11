using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }
        
}
