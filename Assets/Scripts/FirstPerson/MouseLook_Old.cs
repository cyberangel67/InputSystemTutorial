using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook_Old : MouseLook
{
    private void Update()
    {
        Vector2 direction = OldMouseLook();

        DoLook(direction);
    }

    private Vector2 OldMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        return new Vector2(mouseX, mouseY);
    }

}
