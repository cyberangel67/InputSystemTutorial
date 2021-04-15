using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_Action : PlayerMovement
{
    Vector2 Movement() => action.ReadValue<Vector2>();
    protected override bool isRunning() => runAction.IsPressed();
    protected override bool canJump() => jumpAction.triggered && isGrounded();

    InputAction action;
    InputAction jumpAction;
    InputAction runAction;

    private void Awake()
    {
        action = new InputAction(type: InputActionType.Value, binding: "Movement");
        action.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        action.AddCompositeBinding("2DVector(mode=2)")
            .With("Up", "<Gamepad>/leftStick/up")
            .With("Down", "<Gamepad>/leftStick/down")
            .With("Left", "<Gamepad>/leftStick/left")
            .With("Right", "<Gamepad>/leftStick/right");

        jumpAction = new InputAction(type: InputActionType.Button, binding: "<Gamepad>/buttonSouth");
        jumpAction.AddBinding("<Keyboard>/space");

        runAction = new InputAction(type: InputActionType.Button, binding: "<Gamepad>/leftStickPress");
        runAction.AddBinding("<Keyboard>/leftShift");
    }

    private void OnEnable()
    {
        action.Enable();
        jumpAction.Enable();
        runAction.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
        jumpAction.Disable();
        runAction.Disable();
    }

    protected override Vector3 GetDirection()
    {
        return transform.right * Movement().x + transform.forward * Movement().y;
    }

}
