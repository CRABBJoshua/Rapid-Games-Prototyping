using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public float timeSpeed = 1;
    public GameObject Target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Delay());
        }
    }

    public IEnumerator Delay()
    {
        Time.timeScale = timeSpeed;
        yield return new WaitForSeconds(1);
        Time.timeScale = timeSpeed = 1;
        Destroy(gameObject);
    }
}

