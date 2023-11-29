using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    protected Animator basicAnimator;
    protected PlayerAttackState state;
    protected virtual void Start()
    {
        basicAnimator = transform.Find("Player").GetComponent<Animator>();
        basicAnimator.SetBool("attack", false);
        
    }

    public virtual void EnterWeapon()
    {
        basicAnimator.SetBool("attack", true);
       
    }
    

    public virtual void ExitWeapon()
    {
        basicAnimator.SetBool("attack", false);
        
    }

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public void InitializeWeapon(PlayerAttackState state)
    {
        this.state = state;
    }
    
    public virtual void AnimationTurnOffFlipTrigger()
    {
        state.SetFlipCheck(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        state.SetFlipCheck(true);
    }

}
