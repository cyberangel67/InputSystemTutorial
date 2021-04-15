using UnityEngine;

public class PlayerMovement_Old : PlayerMovement
{
    protected override bool isRunning() => Input.GetKey(KeyCode.LeftShift);
    protected override bool canJump() => Input.GetButtonDown("Jump") && isGrounded();

    protected override Vector3 GetDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        return transform.right * x + transform.forward * z;
    }

}
