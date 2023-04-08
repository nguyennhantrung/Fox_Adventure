using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemInterface item;

    public void onInteraction()
    {
        item.onInteraction();
    }
}
