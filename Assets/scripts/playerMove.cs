using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;

    public float runSpeed = 40f ;

    float horizontalMove = 0f ;
   
    bool jump = false ;
    bool crouch = false ;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed ;

        anim.SetFloat("speed",Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true ;
            anim.SetBool("isJumping",true);
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true ;
        }else  if(Input.GetButtonUp("Crouch"))
        {
            crouch = false ;
        }
        Trow();
        Bazzoka();
        Shooting();
    }

    void Trow()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Throwing",true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Throwing",false);
        }
    }
    void Bazzoka()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetBool("bazooka",true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            anim.SetBool("bazooka",false);
        }
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            anim.SetBool("shooting",true);
        }
        if (Input.GetButtonUp("Fire3"))
        {
            anim.SetBool("shooting",false);
        }
    }

    public void OnLanding ()
    {
        anim.SetBool("isJumping",false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }
}
