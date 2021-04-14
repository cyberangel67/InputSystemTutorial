using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Old : MonoBehaviour
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

    void Update()
    {
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        speed = walkSpeed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
