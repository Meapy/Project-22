using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCamera : MonoBehaviour
{
    
    public List<Transform> targets;

    public List<Camera> cameras;
    public Vector3 target_Offset;
    public float speed = 1f;



    // Start is called before the first frame update
    void Start()
    {
        target_Offset = transform.position - targets[0].position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if c is pressed, go to the next target in the array
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(targets[0].name);
            targets.RemoveAt(0);
        }
        //if the array is empty, then add all the planets back to the array
        if (targets.Count == 0)
        {
            targets.Add(GameObject.Find("Mercury").transform);
            targets.Add(GameObject.Find("Venus").transform);
            targets.Add(GameObject.Find("Earth").transform);
            targets.Add(GameObject.Find("Mars").transform);
            targets.Add(GameObject.Find("Jupiter").transform);
        }
        //if targets name is mercury, switch to the MercuryCamera camera object
        if (targets[0].name == "Mercury")
        {
            cameras[0].enabled = true;
            cameras[1].enabled = false;
            //cameras[2].enabled = false;
            //cameras[3].enabled = false;
            //cameras[4].enabled = false;
        }


       // Look
        var newRotation = Quaternion.LookRotation(targets[0].transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);

        // Move
        Vector3 newPosition = targets[0].transform.position - targets[0].transform.forward * target_Offset.z - targets[0].transform.up * target_Offset.y;
        transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * speed);
    }

}
