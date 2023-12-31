using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 



 



  
  
  
  
[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Crouch States")]
    public float crouchMoveVelocity = 5f;
    public float crouchColliderHeight = 0.8f;
    public float standColliderHeight = 1.1f;

  




}



