using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherRotate : MonoBehaviour
{
    public float rotationSpeed = 1f;
    
    void update()
    {
        //rotate an object on the spot
        Vector3 v = transform.localRotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(v.x + rotationSpeed, v.y + rotationSpeed, v.z + rotationSpeed);
    }
}
