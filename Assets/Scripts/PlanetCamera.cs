using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCamera : MonoBehaviour
{
    
    public Transform target;
    public Vector3 target_Offset;
    public float speed = 1f;

    public static bool switched = true;

    // Start is called before the first frame update
    void Start()
    {
        target = SwapCameraScript.targets[0];
        target_Offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
    
        //if switched, update the target target = SwapCameraScript.targets[0];
        if (switched)
        {
            target = SwapCameraScript.targets[0];
            target_Offset = transform.position - target.position;
            switched = false;
        }

       // Look
        var newRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);

        // Move
        Vector3 newPosition = target.transform.position - target.transform.forward * target_Offset.z - target.transform.up * target_Offset.y;
        transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * speed);
    }

}
