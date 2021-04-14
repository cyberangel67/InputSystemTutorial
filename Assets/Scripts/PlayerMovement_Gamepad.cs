using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_Gamepad : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float walkSpeed = 12f;
    [SerializeField] private float runSpeed = 20f;

    private float speed;

    Vector3 velocity;
    bool isGrounded() => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    Vector2 LeftStick() => Gamepad.current != null ? Gamepad.current.leftStick.ReadValue() : Vector2.zero;
    bool JumpPressed() => Gamepad.current != null ? Gamepad.current.buttonSouth.wasPressedThisFrame : false;
    bool IsRunning() => Gamepad.current != null ? Gamepad.current.leftStickButton.IsPressed() : false;
    bool canJump() => JumpPressed() && isGrounded();

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
        if (IsRunning())
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
        return transform.right * LeftStick().x + transform.forward * LeftStick().y;
    }

}
