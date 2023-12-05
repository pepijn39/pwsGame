using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveWeapon : Weapons
{
    protected AgressiveWeaponData agressiveWeaponData;

    private List<IDamageable> detectedDamagable = new List<IDamageable>();


    protected override void Awake()
    {
        base.Awake();

        if (weaponData.GetType() == typeof(AgressiveWeaponData))
        {
            agressiveWeaponData = (AgressiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("verkeerde data voor wapen");
        }
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }


    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = agressiveWeaponData.AttackDetails[attackCounter];


        foreach (IDamageable item in detectedDamagable)
        {
            item.Damage(details.damageAmount);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        
        IDamageable damageable = collision.GetComponent<IDamageable>(); 
        if (damageable != null) 
        {
           
            detectedDamagable.Add(damageable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
           
            detectedDamagable.Remove(damageable);
        }
    }
}



