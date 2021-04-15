using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook_Gamepad : MouseLook
{
    Vector2 RightStick() => Gamepad.current !=null ? Gamepad.current.rightStick.ReadValue() : Vector2.zero;

    void Update()
    {
        Vector2 direction = DoGamepadLook();

        DoLook(direction);
    }

    protected override void DoLook(Vector2 direction)
    {
        direction *= 0.3f;
        base.DoLook(direction);
    }

    private Vector2 DoGamepadLook()
    {
        float mouseX = RightStick().x * mouseSensitivity;
        float mouseY = RightStick().y * mouseSensitivity;
        return new Vector2(mouseX, mouseY);
    }

}
