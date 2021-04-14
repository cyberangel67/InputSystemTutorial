using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Old : MonoBehaviour
{
    [SerializeField] protected CharacterController controller;
    [SerializeField] protected float gravity = -9.81f;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundDistance = 0.4f;
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected float jumpHeight;
    [SerializeField] protected float walkSpeed = 12f;
    [SerializeField] protected float runSpeed = 20f;

    protected float speed;
    Vector3 velocity;

    private bool isGrounded() => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    private bool isRunning() => Input.GetKey(KeyCode.LeftShift);
    private bool canJump() => Input.GetButtonDown("Jump") && isGrounded();

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

        Vector3 direction = GetDirection();
        controller.Move(direction * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private Vector3 GetDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        return transform.right * x + transform.forward * z;
    }
}
