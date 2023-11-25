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

        player.CheckIfShouldFlip(xInput);

        if (setVelocity)
        {
            player.SetVelocityX(velocityToSet * player.FacingDirection);
        }

    }


    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

    public void SetPlayerVelocity(float velocity)
    {
        player.SetVelocityX(velocity * player.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true;
    }
   
}
