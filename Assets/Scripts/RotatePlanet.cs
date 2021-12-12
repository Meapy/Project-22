using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [Range(-100,100)]
    public float rotationSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        // Increment the rotation of the object around the Y axis using planet.rotationSpeed
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
