using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject Target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = Target.GetComponent<PlayerController>();
            playerController.addScore(100);

            Destroy(gameObject);
        }
    }
}
