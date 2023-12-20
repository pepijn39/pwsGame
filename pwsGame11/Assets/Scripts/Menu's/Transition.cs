using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public LevelMove levelMove;
    public Animator transition;
    public int sceneBuildIndex;

    public void LoadLevel()
    {
        print("Switching Scene to " + sceneBuildIndex);
        StartCoroutine(Loading(SceneManager.GetActiveScene().buildIndex));
        
    }

 

    IEnumerator Loading(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneBuildIndex);

    }
}
