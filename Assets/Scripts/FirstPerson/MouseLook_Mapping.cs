using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook_Mapping : MouseLook
{

    private SystemControls controls;
    Vector2 LookMouse() => controls.PlayerControls.LookAround.ReadValue<Vector2>();

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    protected override void Awake()
    {
        base.Awake();
        controls = new SystemControls();
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    private void OnEnable()
    {
        controls.PlayerControls.Enable();
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    private void OnDisable()
    {
        controls.PlayerControls.Disable();
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
