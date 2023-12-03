using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    protected Animator baseAnimator;
    protected Animator weaponAnimator;
    protected PlayerAttackState state;

    protected int attackCounter;
    [SerializeField] private WeaponData weaponData;
   
    protected virtual void Start()
    {
        weaponAnimator = transform.Find("Bite").GetComponent<Animator>();
        // baseAnimator = ...
        gameObject.SetActive(false);
        
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (attackCounter >= weaponData.movementSpeed.Length)
        {
            attackCounter = 0;
        }

        weaponAnimator.SetBool("attack", true);
        //baseAnimator...

        weaponAnimator.SetInteger("attackCounter", attackCounter);

    }
    

    public virtual void ExitWeapon()
    {
        weaponAnimator.SetBool("attack", false);
        //baseAnimator...

        attackCounter++;

        gameObject.SetActive(false);
        
    }

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        state.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    }

    public virtual void AnimationStopMovementTrigger()
    {
        state.SetPlayerVelocity(0f);
    }
 
    
    public virtual void AnimationTurnOffFlipTrigger()
    {
        state.SetFlipCheck(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        state.SetFlipCheck(true);
    }

    public virtual void AnimationActionTrigger()
    {

    }

    public void InitializeWeapon(PlayerAttackState state)
    {
        this.state = state;
    }

}
