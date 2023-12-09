using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    private Animator anim;

    // Update is called once per frame
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
    }
    void Update()
    {
           
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            Flip();
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f )
        {
            Flip();
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
