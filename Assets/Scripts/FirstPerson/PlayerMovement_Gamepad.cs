using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_Gamepad : PlayerMovement
{
    protected override bool isRunning() => Gamepad.current != null ? Gamepad.current.leftStickButton.IsPressed() : false;
    protected override bool canJump() => JumpPressed() && isGrounded();

    Vector2 LeftStick() => Gamepad.current != null ? Gamepad.current.leftStick.ReadValue() : Vector2.zero;
    bool JumpPressed() => Gamepad.current != null ? Gamepad.current.buttonSouth.wasPressedThisFrame : false;

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    protected override Vector3 GetDirection()
    {
        return transform.right * LeftStick().x + transform.forward * LeftStick().y;
    }

}
