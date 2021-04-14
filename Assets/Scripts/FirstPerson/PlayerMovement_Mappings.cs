using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_Mappings : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float walkSpeed = 12f;
    [SerializeField] private float runSpeed = 12f;

    private Vector3 velocity;
    private bool isGrounded() => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    private float speed;

    private SystemControls controls;
    private Vector2 Movement()=> controls.PlayerControls.Movement.ReadValue<Vector2>();

    private bool isRunning() => controls.PlayerControls.Run.IsPressed();
    private bool canJump() => controls.PlayerControls.Jump.triggered && isGrounded();


    private void Awake()
    {
        controls = new SystemControls();
        controls.PlayerControls.Enable();
    }


    private void Update()
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
