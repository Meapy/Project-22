using UnityEngine;
using System.Collections;
 
public class SpaceShipController : MonoBehaviour
{
    KeyCode ascendKey = KeyCode.Space;
    KeyCode descendKey = KeyCode.LeftShift;
    KeyCode rollCounterKey = KeyCode.LeftArrow;
    KeyCode rollClockwiseKey = KeyCode.RightArrow;
    KeyCode PitchUp = KeyCode.UpArrow;
    KeyCode PitchDown = KeyCode.DownArrow;
    KeyCode forwardKey = KeyCode.W;
    KeyCode backwardKey = KeyCode.S;
    KeyCode leftKey = KeyCode.A;
    KeyCode rightKey = KeyCode.D;

    Quaternion targetRot;
    Quaternion smoothedRot;

    public float thrustStrength = 10;
    public float rotSpeed = 5;
    public float rollSpeed = 15;
    public float rotSmoothSpeed = 2.5f;
    public bool lockCursor;
    Vector3 thrusterInput;

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
        float pitchInput = GetInputAxis (PitchUp,PitchDown);
        float yawInput = GetInputAxis (leftKey, rightKey);
        float rollInput = GetInputAxis (rollCounterKey, rollClockwiseKey); //* rollSpeed * Time.deltaTime;

        //smooth Rotation
        targetRot = Quaternion.Euler (pitchInput, yawInput, rollInput) * targetRot;
        smoothedRot = Quaternion.Slerp (smoothedRot, targetRot, rotSmoothSpeed * Time.deltaTime);

        // Apply rotation
        transform.rotation = smoothedRot;

        // Apply thruster force
        if (thrusterInput.magnitude > 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(thrusterInput * thrustStrength);
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