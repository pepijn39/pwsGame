using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    [SerializeField] CharacterController2D controller;
    [SerializeField] float runSpeed = 40f;
    

    bool jump = false;
    float horizontalMove = 0f;
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        

    if (Input.GetButtonDown("Jump"))
    {
        jump = true;
        
    }

    if (Input.GetButtonDown("Crouch"))
    {
        crouch = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    else if (Input.GetButtonUp("Crouch"))
    {
        crouch = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }




    }


   

    private void FixedUpdate()
    {
    //Move our character
    controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    jump = false;
    }
}
