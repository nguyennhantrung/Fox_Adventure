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
    [SerializeField] Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpInput |= inputController.RetrieveJumpInput();
        if(jumpInput)
        {
            if(jumpTime != jumpMaxTime)
            {
                jumpTrigger = true;
            }   
            jumpInput = false;
        }
    }
    private void FixedUpdate() {
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
        }
        if(ground.GetGround() == true && rb.velocity.y == 0)
        {
            jumpTime = 0;
        }
    }

    void UpdateGravityBody()
    {
        if(rb.velocity.y > 0)
        {
            rb.gravityScale = jumpUpGravityScale;
        }
        else if(rb.velocity.y < 0)
        {
            rb.gravityScale = jumpDownGravityScale;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
}
