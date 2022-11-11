using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [Tooltip("Speed of the spinning bar")]
    [Range(-100f, 100f)]
    public float rotSpeed = 25;
    public Vector3 Rotation;

    void Update()
    {
        transform.Rotate(Rotation * rotSpeed * Time.deltaTime);
    }
}
