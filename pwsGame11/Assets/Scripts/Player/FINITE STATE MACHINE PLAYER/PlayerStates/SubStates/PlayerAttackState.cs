using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapons weapon;
 

    private int xInput;

    private float velocityToSet;
    private bool setVelocity;
    private bool shouldCheckFlip;

    public PlayerAttackState(Player player, PlayerStateMachine statemachine, PlayerData playerData, string animBoolName) : base(player, statemachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        setVelocity = false;
        player.attackSound.Play();
        weapon.EnterWeapon();
        
        
        
    }

    public override void Exit()
    {
        base.Exit();

        weapon.ExitWeapon();
        SetPlayerVelocity(0f);
        
        
    }

    public void SetWeapon(Weapons weapon)
    {
        this.weapon = weapon;
        weapon.InitializeWeapon(this);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;

        if (shouldCheckFlip) 
        {
            core.Movement.CheckIfShouldFlip(xInput);
        }

      

        if (setVelocity)
        {
            core.Movement.SetVelocityX(velocityToSet * core.Movement.FacingDirection);
        }

    }


    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

    private void AnimationActionTrigger()
    {
        weapon.AnimationActionTrigger();
    }

    public void SetPlayerVelocity(float velocity)
    {
        core.Movement.SetVelocityX(velocity * core.Movement.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true;
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

  

}
