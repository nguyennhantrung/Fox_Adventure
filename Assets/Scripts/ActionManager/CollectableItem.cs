using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableItem", menuName = "Item/Colectable")]

public class CollectableItem : ItemInterface
{
    [SerializeField] itemInfo item = new itemInfo();
    // Start is called before the first frame update
    void Start()
    {
        item.setDecription("this is collectable object");
        item.setType(itemType.COLLECTABLE);
    }

    public override void onInteraction()
    {
        Debug.Log("this object will be collected");
        // gameObject.SetActive(false);
    }
}
