using System;
using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
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
    protected Vector3 velocity;

    protected bool isGrounded() => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    protected virtual bool canJump() => false;
    protected virtual bool isRunning() => false;

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    protected virtual void Update()
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

    //------------------------------------------------------------------------------------------------------
    //
    //------------------------------------------------------------------------------------------------------
    protected virtual Vector3 GetDirection()
    {
        throw new NotImplementedException();
    }
}
