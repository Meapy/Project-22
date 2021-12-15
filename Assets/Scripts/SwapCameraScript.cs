using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCameraScript : MonoBehaviour
{
    public static List<Transform> targets = new List<Transform>();
    //public List<Camera> cameras;
    public List<GameObject> cameras;
    // Start is called before the first frame update
    void Start()
    {
        addTargets();
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        //if c is pressed, go to the next target in the array
        if (Input.GetKeyDown(KeyCode.C))
        {   
            Debug.Log(targets[0].name + "is removed");
            targets.RemoveAt(0);  
            Debug.Log(targets[0].name + "is added");
        }
        //if the array is empty, then add all the planets back to the array
        if (targets.Count == 0)
        {
            addTargets();
        }
        //if targets name is mercury, switch to the MercuryCamera camera object
        if (targets[0].name == "Mercury")
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
            cameras[2].SetActive(false);
            cameras[3].SetActive(false);
            cameras[4].SetActive(false);
            PlanetCamera.switched = true;
            
        }
        else if (targets[0].name == "Venus")
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
            cameras[2].SetActive(false);
            cameras[3].SetActive(false);
            cameras[4].SetActive(false);
            PlanetCamera.switched = true;
        }
        else if (targets[0].name == "Earth")
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(false);
            cameras[2].SetActive(true);
            cameras[3].SetActive(false);
            cameras[4].SetActive(false);
            PlanetCamera.switched = true;
        }
        else if (targets[0].name == "Mars")
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(false);
            cameras[2].SetActive(false);
            cameras[3].SetActive(true);
            cameras[4].SetActive(false);
            PlanetCamera.switched = true;
        }
        else if (targets[0].name == "Jupiter")
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(false);
            cameras[2].SetActive(false);
            cameras[3].SetActive(false);
            cameras[4].SetActive(true);
            PlanetCamera.switched = true;
        }
    }

    void addTargets()
    {
        targets.Add(GameObject.Find("Earth").transform);
        targets.Add(GameObject.Find("Mercury").transform);
        targets.Add(GameObject.Find("Venus").transform);
        targets.Add(GameObject.Find("Mars").transform);
        targets.Add(GameObject.Find("Jupiter").transform);
    }
}
