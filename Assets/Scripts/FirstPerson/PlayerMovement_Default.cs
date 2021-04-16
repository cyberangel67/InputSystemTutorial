using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_Default : PlayerMovement
{
    float Vertical => Keyboard.current.wKey.ReadValue() - Keyboard.current.sKey.ReadValue();
    float Horizontal => Keyboard.current.dKey.ReadValue() - Keyboard.current.aKey.ReadValue();
    bool KeyJump() => Keyboard.current.spaceKey.wasPressedThisFrame;
    protected override bool isRunning() => Keyboard.current.leftShiftKey.IsPressed();
    protected override bool canJump() => KeyJump() && isGrounded();

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    protected override Vector3 GetDirection()
    {
        Vector3 move = transform.right * Horizontal + transform.forward * Vertical;
        return move;
    }

}
