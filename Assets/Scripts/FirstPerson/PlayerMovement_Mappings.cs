using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_Mappings : PlayerMovement
{
    private SystemControls controls;
    private Vector2 Movement()=> controls.PlayerControls.Movement.ReadValue<Vector2>();
    protected override bool isRunning() => controls.PlayerControls.Run.IsPressed();
    protected override bool canJump() => controls.PlayerControls.Jump.triggered && isGrounded();

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    private void Awake()
    {
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
    protected override Vector3 GetDirection()
    {
        return transform.right * Movement().x + transform.forward * Movement().y;
    }
}
