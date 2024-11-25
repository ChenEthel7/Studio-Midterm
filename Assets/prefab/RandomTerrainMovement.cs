using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTerrainMovement : MonoBehaviour
{
    public float moveSpeed = 1f;          // Speed of movement
    public float horizontalRange = 0.5f;  // Max distance for X and Z movement
    public float verticalRange = 0.2f;    // Max distance for Y (vertical) movement
    public float changeInterval = 2f;     // Interval for changing direction

    private Vector3 initialPosition;      // The starting position of the terrain
    private Vector3 targetPosition;       // The target position to move towards
    private float timeSinceLastChange;    // Timer to track change intervals

    void Start()
    {
        // Record the initial position of the terrain
        initialPosition = transform.position;

        // Set the first random target position
        SetNewTargetPosition();
    }

    void Update()
    {
        // Move towards the target position smoothly
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if it's time to pick a new random position
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange >= changeInterval)
        {
            SetNewTargetPosition();
            timeSinceLastChange = 0;
        }
    }

    void SetNewTargetPosition()
    {
        // Generate a new random target position within the specified ranges
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        float randomY = Random.Range(-verticalRange, verticalRange);
        float randomZ = Random.Range(-horizontalRange, horizontalRange);

        // Set the new target position relative to the initial position
        targetPosition = initialPosition + new Vector3(randomX, randomY, randomZ);
    }
}
