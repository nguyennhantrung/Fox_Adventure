using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    // Input
    [Header("Input")]
    [SerializeField] InputController inputController = null;
    [SerializeField] bool jumpInput = false;
    // Player Component
    Rigidbody2D rb;
    [SerializeField] GroundCheck ground;

    // Jump Propertise
    [Header("Gravity Propertise")]
    [SerializeField, Range(0f, 5f)]float jumpUpGravityScale = 1.7f;
    [SerializeField, Range(0f, 5f)]float jumpDownGravityScale = 3f;
    [SerializeField] float jumpGravity;
    
    [Header("Velocity Propertise")]
    [SerializeField, Range(0f, 5f)]float jumpHeight = 2f;
    [SerializeField] float jumpSpeed;

    [Header("Jump Propertise")]
    [SerializeField] bool jumpTrigger = false;
    [SerializeField, Range(0f, 5f)] int jumpMaxTime = 3;
    [SerializeField] int jumpTime = 0;
    [SerializeField] bool isJumping = false;
    [SerializeField] Vector2 velocity;

    [Header("Coyote Jump Propertise")]
    [SerializeField, Range(0f, 0.5f)] float coyoteTimeMax = 0.3f; 
    [SerializeField] float coyoteTimeCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpInput |= inputController.RetrieveJumpInput();
        
    }
    private void FixedUpdate() {
        CheckJumpCondition();
        Jump();
        UpdateGravityBody();
    }

    void Jump()
    {
        if(jumpTrigger && jumpTime < jumpMaxTime)
        {
            Debug.Log("Jump press!!!");
            // get player velocity
            velocity = rb.velocity;
            // calculate jump speed
            jumpSpeed = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);
            velocity.y = jumpSpeed;
            // apply jump speed to player
            rb.velocity = velocity;
            // set value
            jumpTrigger = false;
            jumpTime++;
            isJumping = true;
        }
        if(ground.GetGround() == true && rb.velocity.y == 0)
        {
            jumpTime = 0;
            isJumping = false;
        }
    }

    void UpdateGravityBody()
    {
        if(rb.velocity.y > 0 && inputController.RetrieveJumpHoldInput())
        {
            rb.gravityScale = jumpUpGravityScale;
        }
        else if(rb.velocity.y < 0 || !inputController.RetrieveJumpHoldInput())
        {
            rb.gravityScale = jumpDownGravityScale;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    void CheckJumpCondition()
    {
        if(ground.GetGround() == true && rb.velocity.y == 0)
        {
            coyoteTimeCounter = coyoteTimeMax;
        }
        else
        {
            coyoteTimeCounter -= Time.fixedDeltaTime;
        }
        if(jumpInput)
        {
            if(isJumping && jumpTime != jumpMaxTime || (!isJumping && coyoteTimeCounter > 0f))
            {
                jumpTrigger = true;
            }   
            jumpInput = false;
        }
    }

    public bool IsJump()
    {
        return isJumping;
    }
}
