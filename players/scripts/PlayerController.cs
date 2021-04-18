using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public float maxSpeed = 10;
    public float jumpForce = 12;
    public float hangTime = 0.2f;
    private float hangCounter;
    private bool facingRight = true;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    
    }

    
    protected override void ComputeVelocity() {
        Vector2 move = Vector2.zero;

        
        move.x = Input.GetAxis("Horizontal");
        

        if(move.x == 0) {
            anim.SetBool("isRunning", false);
        }
        else {
            Flip(move.x);
            anim.SetBool("isRunning", true);
        }

        if (grounded) {
            if (anim.GetBool("isFalling") == true)
                anim.SetBool("isFalling", false);

            hangCounter = hangTime;
          
        }
        else {
            hangCounter -= Time.deltaTime;
                          
        }

        if(Input.GetButtonDown("Jump") && hangCounter > 0f) {
            anim.SetTrigger("jumped");       
            velocity.y = jumpForce;
        }
        else if (Input.GetButtonUp("Jump")) {
            if(velocity.y > 0) 
                velocity.y = velocity.y * 0.5f;
                
        }

        if(velocity.y < -4) {
            anim.SetBool("isFalling", true);
        }

        targetVelocity = move * maxSpeed;
        
    }

    private void Flip(float horiVel) {
        if(horiVel > 0 && !facingRight || horiVel < 0 && facingRight) {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    
}








