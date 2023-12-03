using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveWeapon : Weapons
{
    private List<IDamageable> detectedDamagables = new List<IDamageable>();
    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();
    }

    public void AddToDetected(Collider2D collision)
    {
        Debug.Log("AddToDetected");
        IDamageable damageable = collision.GetComponent<IDamageable>(); 
        if (damageable != null) 
        {
            Debug.Log("Added");
            detectedDamagables.Add(damageable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        Debug.Log("RemoveFromDetected");
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Removed");
            detectedDamagables.Remove(damageable);
        }
    }
}
