using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 



  
  
  
  
  
  
  
  
  
  
  
  
  
public class PlayerJumpState : PlayerAbilityState
{

    private int amountOfJumpsLeft;

    public PlayerJumpState(Player player, PlayerStateMachine statemachine, PlayerData playerData, string animBoolName) : base(player, statemachine, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
        amountOfJumpsLeft--;
        player.InAirState.SetIsJumping();

    }

    public bool CanJump()
    {
        if(amountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetAmountOfJumpsLeft()
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public void DecreaseAmountOfJumpsLeft()
    {
        amountOfJumpsLeft--;
    }

}


