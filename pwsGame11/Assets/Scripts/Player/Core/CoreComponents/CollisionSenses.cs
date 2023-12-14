using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 



 



  
  
public class CollisionSenses : CoreComponent
{
    #region Check Transforms


    public Transform GroundCheck { get => groundCheck; private set => groundCheck = value; }
    public Transform CeilingCheck { get => ceilingCheck; private set => ceilingCheck = value; }
    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }
    public float GroundCheckRadius { get => groundCheckRadius; set => groundCheckRadius = value; }

    [SerializeField]  private Transform groundCheck;
    [SerializeField] private Transform ceilingCheck;
    #endregion

    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    public float slopeDownAngle;
    public float slopeDownAngleOld;
    public Vector2 slopeNormalPerp;




    public bool Ceiling
    {
        get => Physics2D.OverlapCircle(ceilingCheck.position, groundCheckRadius, whatIsGround);
    }

    public bool Grounded
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
   
}



