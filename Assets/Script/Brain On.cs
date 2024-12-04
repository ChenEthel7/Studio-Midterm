using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainOn : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;
    [SerializeField]
    Animator myCam;
    [SerializeField]
    AudioSource mystartCam;
    public bool Brain;
    [System.Serializable]
    public class SoundEvent
    {
        public string name; // Optional identifier
        public AudioSource audioSource; // Reference to the AudioSource
    }

    public SoundEvent[] soundEvents; // Array of sound events
    public bool allowMultipleSounds = true; // Option to play multiple sounds simultaneously
    // Start is called before the first frame update
    private void Start()
    {
        Brain = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player"))&& Brain)
           {
               myAnim.SetTrigger("Brain");
               myCam.SetTrigger("ON");
               mystartCam.Play();
               PlaySounds();
           }
    }
     private void PlaySounds()
    {
        foreach (var soundEvent in soundEvents)
        {
            if (soundEvent.audioSource != null)
            {
                if (allowMultipleSounds || !soundEvent.audioSource.isPlaying)
                {
                    soundEvent.audioSource.Play();
                }
            }
        }
    }
    void Update()
    {
        if(mystartCam.time > 1f)
        {
                mystartCam.Stop();
        }
    }
}
