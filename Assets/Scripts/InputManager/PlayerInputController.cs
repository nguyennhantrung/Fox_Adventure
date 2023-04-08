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

    public override bool RetrieveRunInput()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }
}
