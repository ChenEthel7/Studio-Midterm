using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartOn : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;
    [SerializeField]
    Animator myCam;
    [SerializeField]
    AudioSource mystartCam;
    public bool Heart;
    public bool HeartB;
    public bool HeartE;
    public bool HeartS;
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
        Heart = false;
        HeartB = false;
        HeartE = false;
        HeartS = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("Player")) && Heart && HeartB && HeartE && HeartS )
        {
            myAnim.SetTrigger("Heart");
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
