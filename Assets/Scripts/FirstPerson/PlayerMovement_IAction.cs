using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_IAction : PlayerMovement
{

    [SerializeField] private InputAction movement;

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    protected override Vector3 GetDirection()
    {
        float x = movement.ReadValue<Vector2>().x;
        float z = movement.ReadValue<Vector2>().y;

        return transform.right * x + transform.forward * z;
    }
}
