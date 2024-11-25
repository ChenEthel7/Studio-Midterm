using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThroughHandler : MonoBehaviour
{
    public Transform teleportDestination; // Target location for teleportation

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object falling through is the correct object
        if (other.CompareTag("Player")) // Replace "Player" with the appropriate tag
        {
            // Teleport the object to the destination
            other.transform.position = teleportDestination.position;

            // Optionally reset velocity if the object has a Rigidbody
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // Reset any momentum
            }
        }
    }
}

