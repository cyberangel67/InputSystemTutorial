using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    float xRotation = 0f;


    //Vector2 MousePosition() => Mouse.current.delta.ReadValue();
    //Vector2 RightStick() => Gamepad.current.rightStick.ReadValue();

    //InputAction action;
    //Vector2 GetLookDirection() => action.ReadValue<Vector2>() * mouseSensitivity * Time.deltaTime;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        //If its the old input system then change the sensitivity.
#if UNITY_EDITOR
            mouseSensitivity *= 10;
#endif

        //action = new InputAction(binding: "<Gamepad>/rightStick");
        //action.AddBinding("<Mouse>/delta");
        //action.Enable();

    }

    void Update()
    {
        //Use old mouse input system
        Vector2 direction = OldMouseLook();

        //Use for default new Input.System
        //Vector2 direction = DoDefaultLook();

        //Use for default new Input.System
        //Vector2 direction = DoGamepadLook();

        //Use of simple action.
        //Vector2 direction = GetLookDirection();

        DoLook(direction);
    }

    private void DoLook(Vector2 direction)
    {
        xRotation -= direction.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * direction.x);
    }

    private Vector2 OldMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        return new Vector2(mouseX, mouseY);
    }

    //private Vector2 DoDefaultLook()
    //{
    //    float mouseX = MousePosition().x * mouseSensitivity * Time.deltaTime;
    //    float mouseY = MousePosition().y * mouseSensitivity * Time.deltaTime;

    //    return new Vector2(mouseX, mouseY);
    //}

    //private Vector2 DoGamepadLook()
    //{
    //    float mouseX = RightStick().x * mouseSensitivity * Time.deltaTime;
    //    float mouseY = RightStick().y * mouseSensitivity * Time.deltaTime;

    //    return new Vector2(mouseX, mouseY);
    //}

}