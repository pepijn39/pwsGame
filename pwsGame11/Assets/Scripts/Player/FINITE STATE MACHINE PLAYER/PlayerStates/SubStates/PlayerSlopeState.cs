using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlopeState : PlayerGroundedState
{
    public PlayerSlopeState(Player player, PlayerStateMachine statemachine, PlayerData playerData, string animBoolName) : base(player, statemachine, playerData, animBoolName)
    {
    }

    [SerializeField] private float slopeCheckDistance = 0.5f;
    
    private LayerMask whatIsGround;
    
    
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        SlopeCheck();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SlopeCheck()
    {
        Vector2 checkPos = player.transform.position - new Vector3(0.0f, player.colliderSize.y / 2);

        SlopeCheckVertical(checkPos);
    }

    private void SlopeCheckHorizontal(Vector2 checkPos)
    {
        
    }

    private void SlopeCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, whatIsGround);

        if(hit)
        {
            core.CollisionSenses.slopeNormalPerp = Vector2.Perpendicular(hit.normal);

            core.CollisionSenses.slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            core.CollisionSenses.slopeDownAngleOld = core.CollisionSenses.slopeDownAngle;

            Debug.DrawRay(hit.point, core.CollisionSenses.slopeNormalPerp, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }
    }
}
   
