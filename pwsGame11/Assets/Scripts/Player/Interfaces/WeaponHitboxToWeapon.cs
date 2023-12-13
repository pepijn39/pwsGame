using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class WeaponHitboxToPlayer : MonoBehaviour
{
    private Enemy enemy;
    private CombatTestDummy testDummy;

    private void Awake()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
        collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy);


    }
}



