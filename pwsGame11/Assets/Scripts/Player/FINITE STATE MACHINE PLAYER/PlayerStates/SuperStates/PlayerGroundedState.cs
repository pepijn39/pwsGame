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

    private float slopeCheckDistance = 2f;
    private float slopeDownAngle;
    private float slopeDownAngleOld;
    private float slopeSideAngle;
   
   


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
        else if (isOnSlope && isGrounded)
        {
            core.Movement.SetVelocityX(core.Movement.CurrentVelocity.x * slopeNormalPerp.x * -xInput);
            core.Movement.Rb.velocity = core.Movement.CurrentVelocity;
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
        SlopeCheckHorizontal(checkpos);
    }

    private void SlopeCheckVertical(Vector2 checkpos)
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, slopeCheckDistance, core.CollisionSenses.WhatIsGround);
        if (hit)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;

            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if(slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;

            Debug.DrawRay(hit.point, slopeNormalPerp, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.yellow);
        }

        if(isOnSlope && xInput == 0.0f)
        {
            player.Rb.sharedMaterial = player.fullFriction;
        }
        else
        {
            player.Rb.sharedMaterial = player.slippery;
        }
    }

    private void SlopeCheckHorizontal(Vector2 checkpos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkpos, player.transform.right, slopeCheckDistance, core.CollisionSenses.WhatIsGround);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkpos, -player.transform.right, slopeCheckDistance, core.CollisionSenses.WhatIsGround);

        if (slopeHitFront)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
        }
        else if (slopeHitBack)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        } 
        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }
    }
}

