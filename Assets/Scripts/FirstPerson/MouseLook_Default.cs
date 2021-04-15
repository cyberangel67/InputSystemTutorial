using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook_Default : MouseLook
{

    Vector2 MousePosition() => Mouse.current.delta.ReadValue();

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    void Update()
    {
        Vector2 direction = DoDefaultLook();

        DoLook(direction);
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    protected override void DoLook(Vector2 direction)
    {
        direction *= 0.5f;
        direction *= 0.1f;

        base.DoLook(direction);
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    private Vector2 DoDefaultLook()
    {
        float mouseX = MousePosition().x * mouseSensitivity;
        float mouseY = MousePosition().y * mouseSensitivity;

        return new Vector2(mouseX, mouseY);
    }

}
