using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    // Input
    [Header("Input")]
    [SerializeField] InputController inputController = null;
    [SerializeField] float moveInput = 0;
    [SerializeField] bool runInput = false;
    [SerializeField] bool crounchInput = false;
    // Player Component
    Rigidbody2D rb;
    [SerializeField] GroundCheck ground;
    
    // Move Propertise
    [Header("Acceleration Propertise")]
    [SerializeField, Range(0f, 100f)] float maxGroundAcceleration = 30;
    [SerializeField] float acceleration = 0;
    [Header("Velocity Propertise")]
    [SerializeField, Range(0f, 30f)] float maxRunningVelocity = 15;
    [SerializeField, Range(0f, 30f)] float maxWalkingVelocity = 10;
    [SerializeField, Range(0f, 30f)] float maxCrounchingVelocity = 5;
    [SerializeField] float maxVelocity = 0;
    [SerializeField, Range(0f, 30f)] float fricVelocity = 4;
    [SerializeField] Vector2 desiredVelocity;
    [Header("Move Propertise")]
    [SerializeField] Vector2 velocity;
    [SerializeField] bool isCrounching = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = inputController.RetrieveAxisInput();
        runInput = inputController.RetrieveRunInput();
        crounchInput = inputController.RetrieveCrounchInput();
        maxVelocity = runInput ? maxRunningVelocity : maxWalkingVelocity;
        bool triggerCrounching = false;
        if(ground.GetGround())
        {
            maxVelocity = crounchInput ? maxCrounchingVelocity : maxVelocity;
            if(crounchInput)   
                triggerCrounching = true;
        }
        isCrounching = triggerCrounching;
        // if(isCrounching)
        // {
        //     // TODO: crounching body
        // }
        // else
        // {
        //     // TODO: normal body
        // }
        desiredVelocity = new Vector2(moveInput, 0f) * Mathf.Max(maxVelocity - fricVelocity, 0f);
    }

    private void FixedUpdate() {
        Move();
    }

    void Move()
    {
        // get current player velocity 
        velocity = rb.velocity;
        // calculate accel over time
        acceleration = maxGroundAcceleration * Time.fixedDeltaTime;
        // calculate velocity for player
        velocity.x  = Mathf.MoveTowards(velocity.x, desiredVelocity.x, acceleration);
        // apply new velocity to player
        rb.velocity = velocity;
        // Debug.Log("Player's velocity: " + rb.velocity.x);
    }
}
