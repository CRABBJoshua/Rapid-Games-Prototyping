using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{    
    protected const string playerTag = "Player";
    public Vector3 ResetGravity;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            playerController.RB.velocity = Vector3.zero;
            playerController.RB.angularVelocity = Vector3.zero;
            Physics.gravity = ResetGravity;
            playerController.IsOnXAxis = false;
            playerController.IsOnZAxis = false;
            playerController.IsOnYAxis = false;

            LevelManager.Instance.setPlayerPosition(playerController);
        }
    }
}
