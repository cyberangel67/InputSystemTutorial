using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook_Old : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    float xRotation = 0f;

    float xAccumulator;
    const float Snappiness = 30.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        Vector2 direction = OldMouseLook();

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
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        return new Vector2(mouseX, mouseY);
    }

}
