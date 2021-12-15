# Project-22

Name: Daniel Krasovski

Student Number: C18357323

Class Group: DT282

# Description of the project
this project is a a solar system that the user can navigate through and see the planets and moons that are in the solar system. 
the planets ands moons are prcocedurally generated and the user can move around the solar system. i used a tutorial from Sebastian Lague to help me with the procedural generation of the planets and moons. following this tutorial from episode 1 until episode 7: https://www.youtube.com/watch?v=QN39W020LqU&list=PLFt_AvWsXl0cONs3T0By4puYy6GM22ko8

There is also a more cinematic experience of the solar system. where the user can select between different cinematic cameras to view the solar system and the planets.
The planets rotate around the sun and the moons rotate around the planets. The planets also rotate around their own axis. The sizes of the planets are made to be in scale to their realistic size apart from the Sun and Jupiter because of their sizes.


# Instructions for use
to use the project, just load the sample scene in the unity editor. Depending if you want to play the cinematic version, or fly around using the spaceship. if you want to fly around, you have to enable the SpaceshipCamera Game object and disable the <PlanetName>Camera and CameraSwap Game objects.
To control the spaceship, use the WASD keys, W and S to move forward and backwards, A and D to go side ways, Spacebar to go up, and shift to go down.
To change the cinematic camera, just press C to change the camera. 
The music is played at the start of the scene automatically.
To create more planets, you have to make a new material(Graphics folder), shape and Colour settings(Settings Folder), you add the material to the colour settings and then attatch the planet.cs script to an empty game object.

To attach the skybox, you have to import the asset from https://assetstore.unity.com/packages/3d/environments/sci-fi/real-stars-skybox-lite-116333 (i used the StarSkyBox04)and then drag the skybox into the skybox slot in the unity editor for all the cameras. however it is also possible to just set background type to a black solid colour and you get the same effect.

# How it works
The planets, moon's and the sun's surfaces are procedurally generated. Using the Planet.cs, TerrainFace.cs and the simple and rigid noise filter scripts. The user is able to edit the planets surfaces by playing around with the silders in the Inspector. As seen in this screenshot: ![An image](https://i.gyazo.com/281c8af1ea05f2ade74ca24ebda62180.png)

The planets rotation is done by the OtherRotate.cs script.
```c#
    public float rotationSpeed = 5f;
    public GameObject target;
    void Start()
    {
        //if target is the sun then set the rotationSpeed *= .2f;
        if (target.name == "Sun")
        {
            rotationSpeed *= .2f;
        }
    }
    
    void Update()
    {   
        //rotate an object on the spot or around the sun
        transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

```
The ships movement is done by the SpaceShipController.cs script. and the camera is done by the SpaceshipCamera.cs script. which i heavily modified from one of Sebastian Lague's scripts.
```C#
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
```

## Cameras
For the Cinematic Camera, the user can press C to change the camera. The script is attached to the CameraSwap Game object. which switches between the different camera gameobjects in the project. the individual cameras have the PlanetCamera.cs script attacthed to them which is used to move the camera around the planets. The camera gets its target based on which camera is active at the time.
```C#
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
```
Here is a screenshot of the cinematic camera of Earth, the Moon and Venus: ![An image](https://i.gyazo.com/2f60e8eeeebc086e44035b81763cfa2d.png)


For the Spaceship Camera, depending on what direction the ship is facing, the camera will jump to the correct position and adjust which position it is facing. This is so the user always has a view of the ship and which direction it is heading in. 
```C#
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
```
Here is a screenshot of the spaceship and some of the planets: 
![An image](https://i.gyazo.com/150ae248cc41792a3b296c239674b59b.png)


# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference

| Class/asset | Source |
|-----------|-----------|
| SpaceshipCamera.cs | Self written |
| SwapCameraScrip.cs | Self written |
| PlanetCamera.cs | Self written |
| OtherRotate.cs | Self written |
| RotatePlanet.cs | Self written |
| RotatePlanet.cs | Self written |
| Lighting | Self Done |
| All the Materials and Colour + Shape Settings | Self written |
| SpaceShipController.cs | Modified from [Sebastian Lague](https://github.com/SebLague/Solar-System/blob/Episode_01/Assets/Scripts/Controllers/Ship.cs) |
| All other scripts | Modified/Adapted/Used From [Sebastian Lague](https://www.youtube.com/watch?v=QN39W020LqU&list=PLFt_AvWsXl0cONs3T0By4puYy6GM22ko8) |

| Song: Galaxy | From [MVSE](https://www.youtube.com/watch?v=5GIt806zZow) |


# References
Assets:
Spaceship model: https://assetstore.unity.com/packages/3d/vehicles/air/space-cruiser-1-124172
Skybox: https://assetstore.unity.com/packages/3d/environments/sci-fi/real-stars-skybox-lite-116333

Tutorials:
https://www.youtube.com/watch?v=QN39W020LqU&list=PLFt_AvWsXl0cONs3T0By4puYy6GM22ko8 by Sebastian Lague

# What I am most proud of in the assignment
What I am most proud of in the assignment is with how much i was able to get done, and how much I learned. My favourite part of the project is the cinematic camera on the Earth planet. 

# Proposal submitted earlier can go here:

## This is how to markdown text:

This is *emphasis*

This is a bulleted list

- Item
- Item

This is a numbered list

1. Item
1. Item

This is a [hyperlink](http://bryanduggan.org)

# Headings
## Headings
#### Headings
##### Headings

This is code:

```Java
public void render()
{
	ui.noFill();
	ui.stroke(255);
	ui.rect(x, y, width, height);
	ui.textAlign(PApplet.CENTER, PApplet.CENTER);
	ui.text(text, x + width * 0.5f, y + height * 0.5f);
}
```

So is this without specifying the language:

```
public void render()
{
	ui.noFill();
	ui.stroke(255);
	ui.rect(x, y, width, height);
	ui.textAlign(PApplet.CENTER, PApplet.CENTER);
	ui.text(text, x + width * 0.5f, y + height * 0.5f);
}
```

This is an image using a relative URL:

![An image](images/p8.png)

This is an image using an absolute URL:

![A different image](https://bryanduggandotorg.files.wordpress.com/2019/02/infinite-forms-00045.png?w=595&h=&zoom=2)

This is a youtube video:

[![YouTube](http://img.youtube.com/vi/J2kHSSFA4NU/0.jpg)](https://www.youtube.com/watch?v=J2kHSSFA4NU)

This is a table:

| Heading 1 | Heading 2 |
|-----------|-----------|
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
