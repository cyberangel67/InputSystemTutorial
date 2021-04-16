using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls_Movement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float walkSpeed = 12f;
    [SerializeField] private float runSpeed = 20f;

    private Vector3 velocity;
    private bool isGrounded() => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    private float speed;

    private bool isJumping;

    private bool canJump() => isJumping && isGrounded();

    Vector3 move = Vector3.zero;
    Vector2 direction = Vector2.zero;

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    private void Start()
    {
        speed = walkSpeed;
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    private void Update()
    {
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        move = transform.right * direction.x + transform.forward * direction.y;

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    public void OnMove(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    public void OnJump(InputAction.CallbackContext value)
    {
        if (isGrounded() && value.action.WasPerformedThisFrame())
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    public void OnRun(InputAction.CallbackContext value)
    {
        speed = walkSpeed;
        if (value.action.IsPressed())
        {
            speed = runSpeed;
        }

    }

}
