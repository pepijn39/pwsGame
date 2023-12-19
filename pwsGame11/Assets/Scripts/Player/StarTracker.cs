using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarTracker : MonoBehaviour
{
    public int stars = 0;
   
    public TextMeshProUGUI starTracker;
    

    private void Start()
    {
        starTracker = GameObject.Find("starsText").GetComponent<TextMeshProUGUI>();
        
      
    }
   
      public void StarCounter()
    {
        stars++;
        starTracker.text = "Stars: " + stars;
    }
}



