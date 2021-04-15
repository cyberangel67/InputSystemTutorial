using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls_Camera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    private Vector2 delta;
    private float xRotation = 0f;

    //This is only here so we can enable and disable the script in the
    //inspector, otherwise I would normally not leave this here.
    private void Update()
    {
        delta *= mouseSensitivity;

        xRotation -= delta.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * delta.x);
    }

    public void LookAround(InputAction.CallbackContext value)
    {
        delta = value.ReadValue<Vector2>();
    }

}
