using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapons weapon;
    [SerializeField] private WeaponData weaponData;

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
        SetPlayerVelocity(weaponData.movementSpeed);
        setVelocity = false;
        
    }

    public override void Exit()
    {
        base.Exit();
        SetPlayerVelocity(0f);
        
        
    }

    public void SetWeapon(Weapons weapon)
    {
        this.weapon = weapon;
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
