using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public float timeSpeed = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = timeSpeed;

            Invoke("Delay", 3.0f);
 
        }
    }

    void SetBackToNormal()
    {
        Debug.Log("Delayed!");
        //Time.timeScale = timeSpeed = 1;
    }
}

