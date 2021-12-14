using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCamera : MonoBehaviour
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
            if((target.transform.eulerAngles.y > 60 && target.transform.eulerAngles.y < 140) )
            {

                transform.position = Vector3.Lerp(transform.position, target.position-target_Offset,1.1f);
                transform.position = new Vector3(transform.position.x - 30, transform.position.y + 3.36f, target.transform.position.z);

                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
                //Debug.Log("this is to the right");

            }
            else if((target.transform.eulerAngles.y > 140 && target.transform.eulerAngles.y < 230) )
            {

                transform.position = Vector3.Lerp(transform.position, target.position-target_Offset,1.1f);
                transform.position = new Vector3(transform.position.x, transform.position.y + 3.36f, transform.position.z);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);

                //Debug.Log("this is to the back");
            }
            else if ((target.transform.eulerAngles.y > 230 && target.transform.eulerAngles.y < 320) )
            {
                transform.position = Vector3.Lerp(transform.position, target.position-target_Offset,1.1f);
                transform.position = new Vector3(transform.position.x + 30, transform.position.y + 3.36f, target.transform.position.z);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 270, transform.eulerAngles.z);

                //Debug.Log("this is to the left");
            }
            else
            {   
                transform.position = Vector3.Lerp(transform.position, target.position + target_Offset, 1.1f);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
 
                //Debug.Log("this is to the front");

            }

        }
        //RotateCamera();
    }
}
