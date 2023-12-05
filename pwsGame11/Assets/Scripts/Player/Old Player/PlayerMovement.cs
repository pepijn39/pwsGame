using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] CharacterController2D controller;
    [SerializeField] float runSpeed = 40f;
    public Animator anim;

    bool jump = false;
    float horizontalMove = 0f;
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        runSpeed = 50f;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
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


    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        anim.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
