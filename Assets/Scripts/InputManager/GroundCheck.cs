using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // [SerializeField] CircleCollider2D bottomPoint;
    [SerializeField] CapsuleCollider2D bottomPoint;
    [SerializeField] ContactFilter2D contactFilter;
    [SerializeField] int numCollider = 0;
    [SerializeField] bool onGround = false;

    private void Start() {
        bottomPoint = GetComponent<CapsuleCollider2D>();
    }
    
    private void FixedUpdate() {
        List<Collider2D> results = new List<Collider2D>();
        numCollider = bottomPoint.OverlapCollider(contactFilter, results);
        bool groundCheckAvailable = false;
        foreach (Collider2D col in results)
        {
            if(col.tag == "Ground")
            {
                groundCheckAvailable = true;
                break;
            }
        }
        onGround = groundCheckAvailable;
    }

    public bool GetGround()
    {
        return onGround;
    }
}
