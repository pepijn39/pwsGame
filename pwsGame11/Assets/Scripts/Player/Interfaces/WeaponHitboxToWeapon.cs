using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class WeaponHitboxToPlayer : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyCompenent))
        {
            enemyCompenent.TakeDamage(20f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
        collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy);


    }
}



