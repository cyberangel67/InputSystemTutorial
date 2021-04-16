using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls_Camera : MouseLook
{
    private Vector2 delta;

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    private void Update()
    {
        delta *= mouseSensitivity;
        base.DoLook(delta);
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    public void LookAround(InputAction.CallbackContext value)
    {
        delta = value.ReadValue<Vector2>();
    }

}
