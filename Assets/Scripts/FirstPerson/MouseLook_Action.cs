using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook_Action : MouseLook
{
    InputAction action;
    Vector2 LookMouse() => action.ReadValue<Vector2>();

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    protected override void Awake()
    {
        base.Awake();

        action = new InputAction(type: InputActionType.Value);
        action.AddBinding("<Gamepad>/rightStick", processors: "ScaleVector2(x=1, y=1)");
        action.AddBinding("<Mouse>/delta", processors: "ScaleVector2(x=0.5, y=0.5),ScaleVector2(x=0.1, y=0.1)");
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    private void OnEnable()
    {
        action.Enable();
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    private void OnDisable()
    {
        action.Disable();
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    void Update()
    {
        var delta = LookMouse();
        delta *= mouseSensitivity;
        base.DoLook(delta);
    }

}
