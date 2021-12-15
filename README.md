# Project-22

Name: Daniel Krasovski

Student Number: C18357323

Class Group: Dt282

# Description of the project
this project is a a solar system that the user can navigate through and see the planets and moons that are in the solar system. 
the planets ands moons are prcocedurally generated and the user can move around the solar system. i used a tutorial from Sebastian Lague to help me with the procedural generation of the planets and moons. following this tutorial from episode 1 until episode 7: https://www.youtube.com/watch?v=QN39W020LqU

There is also a more cinematic experience of the solar system. where the user can select between different cinematic cameras to view the solar system and the planets.
The planets rotate around the sun and the moons rotate around the planets. The planets also rotate around their own axis. The sizes of the planets are made to be in scale to their realistic size apart from the Sun and Jupiter because of their sizes.


# Instructions for use
to use the project, just load the sample scene in the unity editor. Depending if you want to play the cinematic version, or fly around using the spaceship. if you want to fly around, you have to enable the SpaceshipCamera Game object and disable the <PlanetName>Camera and CameraSwap Game objects.
To control the spaceship, use the WASD keys, W and S to move forward and backwards, A and D to go side ways, Spacebar to go up, and shift to go down.
To change the cinematic camera, just press C to change the camera. 
The music is played at the start of the scene automatically.
To create more planets, you have to make a new material(Graphics folder), shape and Colour settings(Settings Folder), you add the material to the colour settings and then attatch the planet.cs script to an empty game object. 

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


# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference

| Class/asset | Source |
|-----------|-----------|
| MyClass.cs | Self written |
| MyClass1.cs | Modified from [reference]() |
| MyClass2.cs | From [reference]() |

# References

# What I am most proud of in the assignment
What I am most proud of in the assignment is with how much i was able to get done, and how much I learned. 

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
