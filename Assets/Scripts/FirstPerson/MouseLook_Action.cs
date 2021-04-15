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
    Vector2 LookMouse() => action.ReadValue<Vector2>();

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        action = new InputAction(type: InputActionType.Value);
        action.AddBinding("<Gamepad>/rightStick", processors: "ScaleVector2(x=1, y=1)");
        action.AddBinding("<Mouse>/delta", processors: "ScaleVector2(x=0.5, y=0.5),ScaleVector2(x=0.1, y=0.1)");
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    void Update()
    {
        var delta = LookMouse();

        delta *= mouseSensitivity;
        xRotation -= delta.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * delta.x);
    }

}
