using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapons weapon;

    public PlayerAttackState(Player player, PlayerStateMachine statemachine, PlayerData playerData, string animBoolName) : base(player, statemachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
        
        
    }

    public void SetWeapon(Weapons weapon)
    {
        this.weapon = weapon;
    }
   

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

   
}
