using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MouseLook : MonoBehaviour
{
    [SerializeField] protected float mouseSensitivity = 100f;
    [SerializeField] protected Transform playerBody;

    protected float xRotation = 0f;

    protected virtual void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    protected virtual void DoLook(Vector2 direction)
    {
        xRotation -= direction.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * direction.x);
    }

}
