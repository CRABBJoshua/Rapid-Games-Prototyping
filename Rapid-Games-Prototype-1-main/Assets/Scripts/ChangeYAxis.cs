using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeYAxis : MonoBehaviour
{
    public Vector3 Gravity;
    public GameObject Target;
    public bool Collidered = false;
    public Vector3 ReturnGravity;
    public Vector3 ChangeJumpPower;
    public Vector3 ReturnChangeJumpPower;

    private void OnTriggerEnter(Collider other)
    {

        if (Collidered != true)
        {
            PlayerController playerController = Target.GetComponent<PlayerController>();

            Physics.gravity = Gravity;
            Collidered = true;

            playerController.IsOnYAxis = true;
            playerController.IsOnXAxis = false;
            playerController.IsOnZAxis = false;

            playerController.jump = ChangeJumpPower;
        }
        else
        {
            PlayerController playerController = Target.GetComponent<PlayerController>();

            Physics.gravity = ReturnGravity;
            Collidered = false;

            playerController.IsOnXAxis = false;
            playerController.IsOnZAxis = false;
            playerController.IsOnYAxis = false;

            playerController.jump = ReturnChangeJumpPower;
        }
    }
}
