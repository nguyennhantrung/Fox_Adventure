using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract float RetrieveAxisInput();
    public abstract bool RetrieveRunInput();
    public abstract bool RetrieveJumpInput();

}
