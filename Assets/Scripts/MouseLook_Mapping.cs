using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook_Mapping : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    float xRotation = 0f;

    private SystemControls controls;
    Vector2 LookMouse() => controls.PlayerControls.LookAround.ReadValue<Vector2>();

    private void Awake()
    {
        controls = new SystemControls();
        controls.PlayerControls.Enable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
