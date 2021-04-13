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

    public float speed = 12f;

    Vector3 velocity;
    bool isGrounded() => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    Vector2 GetDirection() => action.ReadValue<Vector2>();

    InputAction action;
    InputAction jumpAction;

    private void Start()
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

        action.Enable();
        jumpAction.Enable();

    }

    void Update()
    {
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * GetDirection().x + transform.forward * GetDirection().y;

        if (jumpAction.triggered && isGrounded())
        {
            Debug.Log($"{jumpAction.triggered}");

            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
