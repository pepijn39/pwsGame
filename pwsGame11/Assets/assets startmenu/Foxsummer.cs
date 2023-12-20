using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Foxsummer : MonoBehaviour
{
    public AudioSource UISound;
    public void LoadScene(string sceneName)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UISound.Play();
            SceneManager.LoadScene("Summer World");
        }
       
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
