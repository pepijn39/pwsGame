using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine {  get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; set; }
    public PlayerCrouchMoveState CrouchMoveState { get; set;}

    [SerializeField]
    private PlayerData playerData;
    
    #endregion

    #region Components
    public Animator Animator { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }    
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region Other Variables
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    #endregion

    #region Check Transforms

    [SerializeField]
    private Transform groundCheck;


    #endregion




    private Vector2 Workspace;


    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData, "crouchMove");

    }



    private void Start()
    {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();

        FacingDirection = 1;

        StateMachine.Initialize(IdleState);
    }



    private void Update()
    {
        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }



    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        Workspace.Set(velocity, CurrentVelocity.y);
        rb.velocity = Workspace;
        CurrentVelocity = Workspace;
    }

    public void SetVelocityY(float velocity)
    {
        Workspace.Set(CurrentVelocity.x, velocity);
        rb.velocity = Workspace;
        CurrentVelocity = Workspace;
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput == FacingDirection)
        {
            Flip();
        }
    }

    private void AnimationTriggerFunction()
    {
        StateMachine.CurrentState.AnimationTrigger();
    }

    private void AnimationFinishTrigger()
    {
        StateMachine.CurrentState.AnimationFinishTrigger();
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

}
