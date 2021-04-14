using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook_Gamepad : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    float xRotation = 0f;

    Vector2 RightStick() => Gamepad.current !=null ? Gamepad.current.rightStick.ReadValue() : Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 direction = DoGamepadLook();

        DoLook(direction);
    }

    private void DoLook(Vector2 direction)
    {

        direction *= 0.3f;

        xRotation -= direction.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * direction.x);
    }

    private Vector2 DoGamepadLook()
    {
        float mouseX = RightStick().x * mouseSensitivity;
        float mouseY = RightStick().y * mouseSensitivity;

        return new Vector2(mouseX, mouseY);
    }

}
