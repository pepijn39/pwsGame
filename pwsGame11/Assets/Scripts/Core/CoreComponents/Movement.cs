using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
   public Rigidbody2D Rb {  get; private set; }

    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity {  get; private set; }

    private Vector2 Workspace;

    protected override void Awake()
    {
        base.Awake();

        Rb = GetComponentInParent<Rigidbody2D>();
        FacingDirection = 1;
    }

    public void LogicUpdate()
    {
        CurrentVelocity = Rb.velocity;
    }


    public void SetVelocityZero()
    {
        Rb.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocityX(float velocity)
    {
        Workspace.Set(velocity, CurrentVelocity.y);
        Rb.velocity = Workspace;
        CurrentVelocity = Workspace;
    }

    public void SetVelocityY(float velocity)
    {
        Workspace.Set(CurrentVelocity.x, velocity);
        Rb.velocity = Workspace;
        CurrentVelocity = Workspace;
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput == FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        Rb.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
