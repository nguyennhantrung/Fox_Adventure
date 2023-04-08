using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInterface : ScriptableObject
{
    protected enum itemType
    {
        COLLECTABLE,
        INTERACTABLE,
        UNDEFINED
    };
    protected class itemInfo
    {
        protected string description;
        protected itemType type;
        public string getDescription()
        {
            return  description;
        }
        public void setDecription(string _description)
        {
            description = _description;
        }
        public itemType getType()
        {
            return  type;
        }
        public void setType(itemType _type)
        {
            type = _type;
        }           
    };
    public abstract void onInteraction();
}
