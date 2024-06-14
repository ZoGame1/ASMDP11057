using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float move = 0f;
    private float speed = 12f;
    public float jumpingPower = 26f;
    private bool isFacingRight = true;
    private bool doubleJump;


    public Animator anim;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask GroundLayer;

    private enum MovementState { idle, running, jumping, falling }



    // Update is called once per frame
    void Update()
    {
        Flip();

        move = Input.GetAxisRaw("Horizontal");
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                doubleJump = !doubleJump;
            }
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        

        UpdateAnimationState();
    }


    private void FixedUpdate()
    {
        

        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, GroundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && move < 0f || !isFacingRight && move > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (move > 0f)
        {
            state = MovementState.running;
        }
        else if (move < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

  

}