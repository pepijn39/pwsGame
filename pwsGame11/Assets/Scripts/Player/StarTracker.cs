using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarTracker : MonoBehaviour
{
    public int stars = 0;
   
    public TextMeshProUGUI starTracker;
    public AudioSource collecting;
    

    private void Start()
    {
        starTracker = GameObject.Find("starsText").GetComponent<TextMeshProUGUI>();
        
      
    }
   
    public void StarCounter()
    {
        collecting.Play();
        stars++;
        starTracker.text = "Stars: " + stars;
        if(stars >= 30)
        {
            //Je hebt het gehaald, transition naar complete scene
        }
    }
}



