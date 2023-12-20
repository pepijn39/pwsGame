using System.Collections;
using System.Collections.Generic;
using UnityEngine;



  
  
  
  
  
  
public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine statemachine, PlayerData playerData, string animBoolName) : base(player, statemachine, playerData, animBoolName)
    {
    }

  
    
    
    private float slopeDownAngle;
    private float slopeDownAngleOld;
    private Vector2 slopeNormalPerp;
    



    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        
            player.walkSound.Play();
        

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        

        core.Movement.CheckIfShouldFlip(xInput);

        core.Movement.SetVelocityX(playerData.movementVelocity * xInput);

        if (!isExitingState)
        {
            if (xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
                player.walkSound.Stop();
            }
            else if (yInput == -1)
            {
                stateMachine.ChangeState(player.CrouchMoveState);
                player.walkSound.Stop();
            }
        }

       
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

  
}
