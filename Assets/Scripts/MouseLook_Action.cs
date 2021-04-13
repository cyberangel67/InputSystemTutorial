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

    float xAccumulator;
    const float Snappiness = 30.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        action = new InputAction(binding: "<Gamepad>/rightStick", processors: "ScaleVector2(x=3,y=2)");
        action.AddBinding("<Mouse>/delta", processors: "ScaleVector2(x=1.5, y=0.9)"); 
        action.Enable();

    }

    void Update()
    {
        Vector2 direction = GetLookDirection();

        xRotation -= direction.y;
        xRotation = Mathf.Clamp(xRotation , -90f, 90f);

        //xAccumulator = Mathf.Lerp(xAccumulator, direction.x, Snappiness * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * direction.x);
    }

}
