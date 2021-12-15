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
        foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet"))
        {
            targets.Add(planet.transform);
            Debug.Log(planet.name);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //if c is pressed, go to the next target in the array
        if (Input.GetKeyDown(KeyCode.C))
        {
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
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
            cameras[2].SetActive(false);
            //cameras[3].enabled = false;
            //cameras[4].enabled = false;
            PlanetCamera.switched = true;
        }
        else if (targets[0].name == "Venus")
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
            cameras[2].SetActive(false);
            //cameras[3].enabled = false;
            //cameras[4].enabled = false;
            PlanetCamera.switched = true;
        }
        else if (targets[0].name == "Earth")
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(false);
            cameras[2].SetActive(true);
            //cameras[3].enabled = false;
            //cameras[4].enabled = false;
            PlanetCamera.switched = true;
        }
    }
}
