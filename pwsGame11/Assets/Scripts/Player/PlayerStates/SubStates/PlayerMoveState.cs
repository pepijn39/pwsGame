using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine statemachine, PlayerData playerData, string animBoolName) : base(player, statemachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(playerData.movementVelocity * xInput);

        if(xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        } else if (yInput == -1) {
            stateMachine.ChangeState(player.CrouchMoveState);

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
