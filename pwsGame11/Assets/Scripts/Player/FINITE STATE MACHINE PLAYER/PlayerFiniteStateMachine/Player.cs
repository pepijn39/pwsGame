using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

 



public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine {  get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set;}
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondaryAttackState { get; private set; }
  //  public PlayerSlopeState SlopeState { get; private set; }

    [SerializeField]
    private PlayerData playerData;
    
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }    
    public Rigidbody2D Rb { get; private set; }
    public BoxCollider2D MovementCollider { get; private set; }
    public CapsuleCollider2D cc { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    public PhysicsMaterial2D slippery;
    public PhysicsMaterial2D fullFriction;
    #endregion

    #region Other Variables
   // public Vector2 CurrentVelocity { get; private set; }
   // public int FacingDirection { get; private set; }
 
    #endregion

   

     private Vector2 Workspace;
     public Vector2 colliderSize;

    #region Unity Oproepers
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData, "crouchMove");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
        SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
      //  SlopeState = new PlayerSlopeState(this, StateMachine, playerData, "slope");
    }


    
    private void Start()
    {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Rb = GetComponent<Rigidbody2D>();
        
        Inventory = GetComponent<PlayerInventory>();
        cc = GetComponent<CapsuleCollider2D>();

        colliderSize = cc.size;

        PrimaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.primary]);
        

        StateMachine.Initialize(IdleState);
    }



    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
       
 
    }



    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion


  

   




    public void SetColliderHeight(float height)
    {
        Vector2 center = cc.offset;
        Workspace.Set(cc.size.x, height);

        center.y += (height - cc.size.y) / 2;

        cc.size = Workspace;
        cc.offset = center;
    }

    private void AnimationTriggerFunction()
    {
        StateMachine.CurrentState.AnimationTrigger();
    }

    private void AnimationFinishTrigger()
    {
        StateMachine.CurrentState.AnimationFinishTrigger();
    }

   

}

