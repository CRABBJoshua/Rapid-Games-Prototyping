using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public Vector3 GravityChange;
    public GameObject Player;
    private bool ChangeControls;
    public bool IsCollidered = false;
    public Vector3 ReturnGravityChange;
    public Vector3 ChangeJumpForce;
    public Vector3 ReturnChangeJumpForce;

    private void OnTriggerEnter(Collider other)
    {

        if (IsCollidered != true)
        {
            PlayerController playerController = Player.GetComponent<PlayerController>();

            playerController.IsOnZAxis = true;
            playerController.IsOnYAxis = false;
            playerController.IsOnXAxis = false;

            Physics.gravity = GravityChange;
            IsCollidered = true;

            playerController.jump = ChangeJumpForce;
        }
        else
        {
            PlayerController playerController = Player.GetComponent<PlayerController>();

            playerController.IsOnXAxis = false;
            playerController.IsOnZAxis = false;
            playerController.IsOnYAxis = false;


            Physics.gravity = ReturnGravityChange;

            IsCollidered = false;

            playerController.jump = ReturnChangeJumpForce;
            Debug.Log("Jump Changed");
        }
    }
}