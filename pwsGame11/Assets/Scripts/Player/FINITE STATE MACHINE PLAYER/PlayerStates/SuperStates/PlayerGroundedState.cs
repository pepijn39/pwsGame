using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 




  
  
  
  
  
  
  
  
public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;
    
    protected bool isTouchingCeiling;

    private bool JumpInput;
    private bool isGrounded;
    private bool isOnSlope;

    private float slopeCheckDistance = 1.75f;
    private float slopeDownAngle;
    private float slopeDownAngleOld;

    private Vector2 slopeNormalPerp;


    public PlayerGroundedState(Player player, PlayerStateMachine statemachine, PlayerData playerData, string animBoolName) : base(player, statemachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = core.CollisionSenses.Grounded;
        isTouchingCeiling = core.CollisionSenses.Ceiling;
      
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        JumpInput = player.InputHandler.JumpInput;
        SlopeCheck();
      


        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary] && !isTouchingCeiling)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        } else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary] && !isTouchingCeiling)
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
       else if(JumpInput && player.JumpState.CanJump() && !isTouchingCeiling)
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        else if (!isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.InAirState);
        } 
    }


  

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SlopeCheck()
    {
        Vector2 checkpos = player.transform.position - new Vector3(0.0f, player.colliderSize.y / 2);
        SlopeCheckVertical(checkpos);
    }

    private void SlopeCheckVertical(Vector2 checkpos)
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, slopeCheckDistance, core.CollisionSenses.WhatIsGround);
        if (hit)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit.normal);

            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if(slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;

            Debug.DrawRay(hit.point, slopeNormalPerp, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.yellow);
        }
    }

    private void SlopeCheckHorizontal(Vector2 checkpos)
    {

    }
}

