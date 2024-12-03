using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCueManager : MonoBehaviour
{
    public Transform player;       // Reference to the player
    public Transform targetObject; // Reference to the target object
    public AudioSource audioSource; // The audio source component on the target

    void Start()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play(); // Ensure the sound is always playing
        }
    }

    void Update()
    {
        // Calculate the direction from the player to the target object
        Vector3 directionToTarget = targetObject.position - player.position;

        // Optionally, adjust the volume based on orientation
        float angle = Vector3.Angle(player.forward, directionToTarget.normalized);

        // Make volume decrease as the angle increases
        audioSource.volume = Mathf.Clamp01(1 - angle / 180f);

        // (Optional) Pan sound left or right based on the relative position
        Vector3 playerToTarget = player.InverseTransformPoint(targetObject.position);
        audioSource.panStereo = Mathf.Clamp(playerToTarget.x / 10f, -1f, 1f); // Adjust stereo pan
    }
}
