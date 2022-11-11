using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegJump : MonoBehaviour
{
    public float bounceScale = 1000.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            Vector3 playerPosition = playerController.transform.position;
            Vector3 pegPosition = transform.position;

            Vector3 towardPlayer = playerPosition - pegPosition;
            towardPlayer.Normalize();

            playerController.RB.AddForce(towardPlayer * bounceScale, ForceMode.Force);
            playerController.addScore(100);



        }
    }
}
