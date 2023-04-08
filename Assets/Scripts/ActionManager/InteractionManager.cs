using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    // Input
    [Header("Input")]
    [SerializeField] InputController inputController = null;
    [SerializeField] bool interactionInput = false;

    // Player Component
    [SerializeField] GameObject interactionCheck;

    //Interaction System
    [SerializeField] GameObject colliderObject;

    // Update is called once per frame
    void Update()
    {
        interactionInput = inputController.RetrieveInteractionInput();
        if(interactionInput)
        {
            colliderObject = interactionCheck.GetComponent<InteractionCheck>().GetInteractionCollider();
            if(colliderObject != null)
            {
                if(colliderObject.tag == "Item")
                {
                    colliderObject.GetComponent<Item>().onInteraction();
                }
            }
        }
    }
}
