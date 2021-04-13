using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook_Old : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

#if UNITY_EDITOR
        mouseSensitivity *= 10;
#endif
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
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        return new Vector2(mouseX, mouseY);
    }

}
