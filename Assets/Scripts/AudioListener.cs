using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListener : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        
        audioSource.Play();
    }
}
