using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTeleport : MonoBehaviour
{
    public Transform teleportDestination; // The object or location to teleport to

    private void OnTriggerEnter(Collider other)
    {
        // Check if the touching object is the Player
        if (other.CompareTag("Player")) // Replace "Player" with your tag
        {
            // Teleport the player to the destination
            other.transform.position = teleportDestination.position;

            // Reset velocity if the Player has a Rigidbody
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // Stop momentum
            }
        }
    }
}
