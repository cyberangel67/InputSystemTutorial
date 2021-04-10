using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Transform TankTurret;
    [SerializeField] private Transform TankBottom;

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        float turretHorizontal = Input.GetAxisRaw("RS_Horizontal");
        float turretVertical = Input.GetAxisRaw("RS_Vertical");
        Vector3 turretMovement = new Vector3(turretHorizontal, 0.0f, turretVertical);

        if (movement != Vector3.zero)
        {
            TankBottom.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }

        if (turretMovement != Vector3.zero)
        {
            TankTurret.rotation = Quaternion.LookRotation(turretMovement);
            //TankTurret.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }

    }
}
