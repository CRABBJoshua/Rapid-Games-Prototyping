using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeXAxis : MonoBehaviour
{
    public Vector3 PhysicsChange;
    public GameObject ThePlayer;
    public bool Collision = false;
    public Vector3 ReturnPhysics;
    public Vector3 ChangeHeightPower;
    public Vector3 ReturnChangeHeightPower;

    private void OnTriggerEnter(Collider other)
    {

        if (Collision != true)
        {
            PlayerController playerController = ThePlayer.GetComponent<PlayerController>();

            Physics.gravity = PhysicsChange;
            Collision = true;

            playerController.IsOnXAxis = true;

            playerController.jump = ChangeHeightPower;
        }
        else
        {
            PlayerController playerController = ThePlayer.GetComponent<PlayerController>();

            Physics.gravity = ReturnPhysics;
            Collision = false;

            playerController.IsOnXAxis = false;
            playerController.IsOnZAxis = false;
            playerController.IsOnYAxis = false;

            playerController.jump = ReturnChangeHeightPower;
        }
    }
}
