using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepAudio; // Assign the AudioSource
    public float walkingSpeedThreshold = 0.1f; // Minimum speed to play footsteps
    public CharacterController characterController; // Assign your Character Controller

    void Update()
    {
        // Check if the player is moving
        if (characterController != null)
        {
            if (characterController.velocity.magnitude > walkingSpeedThreshold)
            {
                // Play the sound if not already playing
                if (!footstepAudio.isPlaying)
                {
                    footstepAudio.Play();
                }
            }
            else
            {
                // Stop the sound if the player stops moving
                if (footstepAudio.isPlaying)
                {
                    footstepAudio.Stop();
                }
            }
        }
    }
}
