using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Player Components")]
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    [SerializeField] GroundCheck groundCheck;
    [SerializeField] InputController inputController = null;
    [SerializeField] MoveController moveController;
    [SerializeField] JumpController jumpController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        groundCheck = GetComponent<GroundCheck>();
        moveController = GetComponent<MoveController>();
        jumpController = GetComponent<JumpController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        onMove();
        onJump();
    }

    void onMove()
    {
        //face direction && animation
        if(rb.velocity.x > 0)
        {
            //move right
            sr.flipX = false;

        }
        else if(rb.velocity.x < 0)
        {
            //move left
            sr.flipX = true;
        }
        animator.SetBool("Walking", inputController.RetrieveAxisInput() != 0);
        animator.SetBool("Running", inputController.RetrieveRunInput());
        
    }
    void onJump()
    {
        if(rb.velocity.y > 0)
        {
            // jumping
        }
        else if (rb.velocity.y < 0)
        {
            //failing
        }
        animator.SetFloat("YVel", rb.velocity.y);
        Debug.Log("YVel: " + rb.velocity.y); 
        animator.SetBool("OnGround", groundCheck.GetGround());
        animator.SetBool("Jumping", jumpController.IsJump());
    }
}
