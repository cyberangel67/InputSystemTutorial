using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Transform TankTurret;
    [SerializeField] private Transform TankBottom;

    private Rigidbody rb;

    private void Awake()
    {
        rb = TankBottom.gameObject.GetComponent<Rigidbody>();        
    }

    void Update()
    {
        Vector3 movement = GetTankMovement();
        Vector3 turretMovement = GetTurretRotation();

        if (movement != Vector3.zero)
        {
            TankBottom.rotation = Quaternion.LookRotation(movement);
            Vector3 desiredVelocity = movement * movementSpeed;
            rb.velocity = desiredVelocity;
        } else
        {
            rb.velocity = Vector3.zero;
        }

        if (turretMovement != Vector3.zero)
        {
            TankTurret.rotation = Quaternion.LookRotation(turretMovement);
        }

    }

    private Vector3 GetTankMovement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        return new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    private Vector3 GetTurretRotation()
    {
        float turretHorizontal = Input.GetAxisRaw("RS_Horizontal");
        float turretVertical = Input.GetAxisRaw("RS_Vertical");

        return new Vector3(turretHorizontal, 0.0f, turretVertical);
    }

}
