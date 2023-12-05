using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 



 


public class WeaponHitboxToPlayer : MonoBehaviour
{
    private AgressiveWeapon weapon;

    private void Awake()
    {
        weapon = GetComponentInParent<AgressiveWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        weapon.AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
        weapon.RemoveFromDetected(collision);
    }
}



