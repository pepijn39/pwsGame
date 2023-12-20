using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public AudioSource teleport;
    public Transition transition;

    private void Start()
    {
        transition = GameObject.Find("Crossfade").GetComponent<Transition>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transition.LoadLevel();
            teleport.Play();
        }
    }

  
}
