using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherRotate : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject target;
    
    void Update()
    {
        //rotate an object on the spot
        transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        Debug.Log("this is getting called");
    }
}
