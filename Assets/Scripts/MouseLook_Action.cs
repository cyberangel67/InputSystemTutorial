using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook_Action : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    float xRotation = 0f;

    InputAction action;
    Vector2 GetLookDirection() => action.ReadValue<Vector2>() * mouseSensitivity * Time.deltaTime;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        action = new InputAction(binding: "<Gamepad>/rightStick", processors: "ScaleVector2(x=2,y=2)");
        action.AddBinding("<Mouse>/delta");
        action.Enable();

    }

    void Update()
    {
        Vector2 direction = GetLookDirection();

        xRotation -= direction.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * direction.x);
    }

}
