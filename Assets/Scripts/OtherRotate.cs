using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherRotate : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public GameObject target;
    void Start()
    {
        //if target is the sun then set the rotationSpeed *= .2f;
        if (target.name == "Sun")
        {
            rotationSpeed *= .2f;
        }
    }
    
    void Update()
    {   

        //rotate an object on the spot or around the sun
        transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
