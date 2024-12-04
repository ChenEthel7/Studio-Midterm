using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCueManager : MonoBehaviour
{
    public Transform player;       // Reference to the player
    public Transform targetObject; // Reference to the target object
    public AudioSource audioSource; // The audio source component on the target
    public float maxVolume = 1.0f;  // Maximum volume of the sound
    public float minVolume = 0.1f;  // Minimum volume of the sound
    public float maxDistance = 20f; // Maximum distance at which the sound is faint

    void Start()
    {
        // Ensure the sound starts playing
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        // Calculate the distance between the player and the target object
        float distance = Vector3.Distance(player.position, targetObject.position);

        // Map the distance to a volume range (inverse relationship)
        float volume = Mathf.Clamp(1 - (distance / maxDistance), minVolume, maxVolume);

        // Set the audio source volume
        audioSource.volume = volume;
    }
}
