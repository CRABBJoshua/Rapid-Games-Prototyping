using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject target;
    public float distance = 11;
    public bool lockHoriz;

    Vector3 pos;
    private Camera cam;

    public float angle;
    public float upDistance = 1f;


    void Start()
    {
        cam = GetComponent<Camera>();
        cam.transform.rotation = Quaternion.Euler(30, -135, 0);
    }

    public Vector3 offsetDirection;

    void Update()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerController>().gameObject;
        }

        if (target != null)
        {
            float maxXZ = Mathf.Max(target.transform.position.x, target.transform.position.z);

            if (lockHoriz == false)
            {
                //transform.position = target.transform.position + new Vector3(distance, distance, distance);
                //transform.position = target.transform.position + offsetDirection.normalized * distance;
                //transform.LookAt(target.transform.position);

                var x = Mathf.Sin(angle * Mathf.Deg2Rad) * distance;
                var z = Mathf.Cos(angle * Mathf.Deg2Rad) * distance;

                var offsetPos = new Vector3(x, upDistance, z);

                transform.position = target.transform.position + offsetPos;
                transform.LookAt(target.transform.position);
            }
            else
            {
                transform.position = new Vector3(maxXZ, target.transform.position.y, maxXZ) + new Vector3(distance, distance, distance);
            }
        }
    }
}
