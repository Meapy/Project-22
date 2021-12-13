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
            if(target.transform.eulerAngles.y > 100 && target.transform.eulerAngles.y < 180 || target.transform.eulerAngles.y <= -180 && target.transform.eulerAngles.y >= -100)
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z + 30);
                float zAxis = target.transform.position.z + 30;
                transform.position = Vector3.Lerp(transform.position, target.position-target_Offset,1.1f);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
                Debug.Log("#2 is called");
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, target.position+target_Offset, 1.1f);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                Debug.Log("#1 is called");
            }

        }
        RotateCamera();
    }
    void RotateCamera()
    {
        if(Input.GetMouseButton(0))
        {
            transform.RotateAround(transform.position, transform.up, -Input.GetAxis("Mouse X")*speed);

            transform.RotateAround(transform.position, transform.right,-Input.GetAxis("Mouse Y")*speed);
        }
    }
}
