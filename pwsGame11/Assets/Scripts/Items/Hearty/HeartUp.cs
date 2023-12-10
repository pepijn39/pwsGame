using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUp : MonoBehaviour
{
    public PlayerHealth health;


    private void Start()
    {
        health = GetComponentInParent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CompareTag("Player"))
        {
            Debug.Log("Touching tips");
        }
    }
        
}
