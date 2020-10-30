using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMotion : MonoBehaviour
{
    public GameObject camTarget;
    Vector3 newDirection;
    void LateUpdate()
    {
        newDirection = new Vector3(camTarget.transform.position.x, transform.position.y, transform.position.z);
        if (newDirection != null)
        transform.position = newDirection;      

        transform.LookAt(camTarget.transform); 
    }


}

//FOR REFERENCE

//https://answers.unity.com/questions/36255/lookat-to-only-rotate-on-y-axis-how.html//
// transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime);