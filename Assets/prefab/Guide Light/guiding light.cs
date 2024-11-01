using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guidinglight : MonoBehaviour
{
    public Transform player;  // The player the light is leading
    public Transform targetDestination;  // Where the light is trying to lead the player
    public float moveSpeed = 2f;  // Speed at which the light moves
    public float maxDistanceFromPlayer = 5f;  // Maximum distance the light can be from the player

    private Vector3 destination;

    void Start()
    {
        destination = targetDestination.position;  // Set the target destination
    }

    void Update()
    {
        // Calculate the distance between the player and the light
        float distanceFromPlayer = Vector3.Distance(transform.position, player.position);

        // If the light is within the maxDistanceFromPlayer, move toward the destination
        if (distanceFromPlayer <= maxDistanceFromPlayer)
        {
            MoveTowardsDestination();
        }
        else
        {
            // If the light is too far from the player, stop moving
            StopMoving();
        }
    }

    void MoveTowardsDestination()
    {
        // Move the light towards the destination
        Vector3 direction = (destination - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void StopMoving()
    {
        // Keep the light still until the player catches up
        // You can add flickering effects or animations here if desired
    }
}
