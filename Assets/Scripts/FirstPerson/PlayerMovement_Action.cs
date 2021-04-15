using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_Action : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float walkSpeed = 12f;
    [SerializeField] private float runSpeed = 20f;

    Vector3 velocity;
    bool isGrounded() => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    Vector2 Movement() => action.ReadValue<Vector2>();
    bool isRunning() => runAction.IsPressed();
    bool canJump() => jumpAction.triggered && isGrounded();

    InputAction action;
    InputAction jumpAction;
    InputAction runAction;

    private float speed;

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

    void Update()
    {
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (canJump())
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        speed = walkSpeed;
        if (isRunning() && isGrounded())
        {
            speed = runSpeed;
        }

        Vector3 move = GetDirection();
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private Vector3 GetDirection()
    {
        return transform.right * Movement().x + transform.forward * Movement().y;
    }

}
