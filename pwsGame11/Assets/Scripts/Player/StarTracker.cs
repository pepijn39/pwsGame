using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarTracker : MonoBehaviour
{
    public int stars = 0;
    public GameObject pickupEffect;
    public TextMeshProUGUI starTracker;

    private void Start()
    {
        starTracker = GameObject.Find("starsText").GetComponent<TextMeshProUGUI>();
       
    }
   



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {

            Instantiate(pickupEffect, transform.position, transform.rotation);

            Destroy(collision.gameObject);
            stars++;
            starTracker.text = "Stars: " + stars;

        }
    }



    public void Pickup()
    {

        

    }
}



