using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerController", menuName = "Input Manager/Player")]

public class PlayerInputController : InputController
{
    public override float RetrieveAxisInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override bool RetrieveCrounchInput()
    {
        return Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
    }

    public override bool RetrieveInteractionInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    public override bool RetrieveJumpHoldInput()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);throw new System.NotImplementedException();
    }

    public override bool RetrieveJumpInput()
    {
        return Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    }

    public override bool RetrieveRunInput()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }
}
