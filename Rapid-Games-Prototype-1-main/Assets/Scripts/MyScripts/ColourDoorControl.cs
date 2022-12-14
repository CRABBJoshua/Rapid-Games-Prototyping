using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourDoorControl : MonoBehaviour
{
    public Texture entryTexture;
    public GameObject Leftdoor;
    public GameObject Rightdoor;
    public Vector3 DoorMovement;
    bool HasOpenDoor = false;

    private void OnTriggerEnter(Collider other)
    {
        //If they've already opened the door, dont do anything below this line
        if (HasOpenDoor)
            return;

        if (other.tag == "Player")
        {
            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();

            if (meshRenderer.materials[0].mainTexture == entryTexture)
            {
                HasOpenDoor = true;
                Debug.Log("Correct");
                Leftdoor.transform.position = Leftdoor.transform.position + DoorMovement;
                Rightdoor.transform.position = Rightdoor.transform.position - DoorMovement;
                
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();
            
    //        if(meshRenderer.materials[0].mainTexture == entryTexture)
    //        {
    //            Debug.Log("Closed");
    //            Leftdoor.transform.position = Leftdoor.transform.position - DoorMovement;
    //            Rightdoor.transform.position = Rightdoor.transform.position + DoorMovement;
    //        }
    //    }
    //}
}

