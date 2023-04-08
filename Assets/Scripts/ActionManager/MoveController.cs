using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    // Input
    [Header("Input")]
    [SerializeField] InputController inputController = null;
    [SerializeField] float moveInput = 0;
    // Player Component
    Rigidbody2D rb;
    
    // Move Propertise
    [Header("Acceleration Propertise")]
    [SerializeField, Range(0f, 100f)] float maxGroundAcceleration = 30;
    [SerializeField] float acceleration = 0;
    [Header("Velocity Propertise")]
    [SerializeField, Range(0f, 30f)] float maxVelocity = 10;
    [SerializeField, Range(0f, 30f)] float fricVelocity = 4;
    [SerializeField] Vector2 desiredVelocity;
    [Header("Move Propertise")]
    [SerializeField] Vector2 velocity;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = inputController.RetrieveAxisInput();
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
        Debug.Log(rb.velocity.x);
    }


}
