using UnityEngine;
using System.Collections;
 
public class SpaceShipController : MonoBehaviour
{
    KeyCode ascendKey = KeyCode.Space;
    KeyCode descendKey = KeyCode.LeftShift;
    KeyCode rollCounterKey = KeyCode.Q;
    KeyCode rollClockwiseKey = KeyCode.E;
    KeyCode forwardKey = KeyCode.W;
    KeyCode backwardKey = KeyCode.S;
    KeyCode leftKey = KeyCode.A;
    KeyCode rightKey = KeyCode.D;

    Quaternion targetRot;
    Quaternion smoothedRot;
    Rigidbody rb;

    public float thrustStrength = 10;
    public float rotSpeed = 5;
    public float rollSpeed = 15;
    public float rotSmoothSpeed = 5;
    public bool lockCursor;
    Vector3 thrusterInput;
    int numCollisionTouches = 0;

    void Start()
    {
        targetRot = transform.rotation;
        smoothedRot = transform.rotation;
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    void Update()
    {
        Movement();
    }

    void Movement ()
    {
        // Thruster input
        int thrustInputX = GetInputAxis (leftKey, rightKey);
        int thrustInputY = GetInputAxis (descendKey, ascendKey);
        int thrustInputZ = GetInputAxis (backwardKey, forwardKey);
        thrusterInput = new Vector3 (thrustInputX, thrustInputY, thrustInputZ);

        // Rotation input
        float yawInput = rotSpeed;
        float pitchInput = rotSpeed;
        float rollInput = GetInputAxis (rollCounterKey, rollClockwiseKey) * rollSpeed * Time.deltaTime;

        //smooth Rotation
        targetRot = Quaternion.Euler (pitchInput, yawInput, rollInput) * targetRot;
        smoothedRot = Quaternion.Slerp (smoothedRot, targetRot, rotSmoothSpeed * Time.deltaTime);

        // Apply rotation
        transform.rotation = smoothedRot;

        // Apply thruster force
        if (thrusterInput.magnitude > 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce (thrusterInput * thrustStrength);
        }



    }

    int GetInputAxis (KeyCode negativeAxis, KeyCode positiveAxis) 
    {
        int axis = 0;
        if (Input.GetKey (positiveAxis)) {
            axis++;
        }
        if (Input.GetKey (negativeAxis)) {
            axis--;
        }
        return axis;
    }

}