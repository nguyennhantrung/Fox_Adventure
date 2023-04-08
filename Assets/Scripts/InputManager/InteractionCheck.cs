using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCheck : MonoBehaviour
{
    [SerializeField] Collider2D interactionCollider;
    
    private void OnTriggerEnter2D(Collider2D other) {
        interactionCollider = other;
    }
    private void OnTriggerStay2D(Collider2D other) {
        interactionCollider = other;
    }
    private void OnTriggerExit2D(Collider2D other) {
        interactionCollider = null;
    }

    public GameObject GetInteractionCollider()
    {
        if(interactionCollider != null)
            return interactionCollider.gameObject;
        else
            return null;
    }
}
