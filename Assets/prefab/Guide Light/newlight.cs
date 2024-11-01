using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class newlight : MonoBehaviour
{
    public Transform player;  // The player the light follows
    public Transform targetDestination;  // The object or destination the light leads to
    public float moveSpeed = 3f;  // Speed of the guiding light movement
    public float maxDistanceFromPlayer = 5f;  // Maximum distance the light can be from the player
    public float minDistanceFromPlayer = 1.5f;  // Minimum distance the light should maintain from the player

    void Update()
    {
        // Calculate the distance between the player and the light
        float distanceFromPlayer = Vector3.Distance(transform.position, player.position);

        // If the light is within the allowed range of the player, move toward the target destination
        if (distanceFromPlayer <= maxDistanceFromPlayer && distanceFromPlayer >= minDistanceFromPlayer)
        {
            MoveTowardsTarget();
        }
        else if (distanceFromPlayer > maxDistanceFromPlayer)
        {
            // If the light is too far from the player, stop moving
            StopMoving();
        }
    }

    void MoveTowardsTarget()
    {
        // Calculate the direction towards the target destination
        Vector3 direction = (targetDestination.position - transform.position).normalized;

        // Zero out the Y axis to ensure horizontal movement
        direction.y = 0;

        // Move the light towards the target on the XZ plane
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void StopMoving()
    {
        // Optional: Add behavior for when the light stops moving
    }
}
