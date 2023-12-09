using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maximumHealth = 50f;
    public GameObject player;
    public float speed;
    public Animator animator;
    

    private float distance;

    private void Start()
    {
        health = maximumHealth;
        Flip();
    }

    private void Update()
    {
        
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        
        
        
         
        
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerComponent))
        {
            
            playerComponent.TakeDamage(20);
            animator.SetBool("attack", true);
           
        }

       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("attack", false);
    }


    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
