using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 target_Offset;
    public float speed = 1f;

    private void Start()
    {
        target_Offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position+target_Offset, 1.1f);
        }
        RotateCamera();
        // if c is pressed, update camera position
        if (Input.GetKeyDown(KeyCode.C))
        {
            UpdateCamera();
        }
    }
    void RotateCamera()
    {
        if(Input.GetMouseButton(0))
        {
            transform.RotateAround(transform.position, transform.up, -Input.GetAxis("Mouse X")*speed);

            transform.RotateAround(transform.position, transform.right,-Input.GetAxis("Mouse Y")*speed);
        }
    }
    void UpdateCamera()
    {
        // if the target rotation is between -140 to -180 or 140 to 180 then change the camera position z axis to be +20 else -20
        if(target.transform.eulerAngles.y > 140 && target.transform.eulerAngles.y < 180 || target.transform.eulerAngles.y > -180 && target.transform.eulerAngles.y < -140)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 30);
            //change the camera rotation y axis to be -180
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
            Debug.Log("#1 is called");
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 30);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y -180, transform.eulerAngles.z);
            Debug.Log("#2 is called");

        }  
    }
}
