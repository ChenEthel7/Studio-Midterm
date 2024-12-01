using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ButterflyMovement : MonoBehaviour
{
    public float speed = 2f;          // Movement speed of the butterfly
    public float flightHeight = 3f;   // Average height the butterfly should fly at
    public float changeDirectionTime = 3f; // Time before changing direction

    private Vector3 randomDirection;
    private float timer;

    void Start()
    {
        SetNewRandomDirection();  // Set an initial random direction
    }

    void Update()
    {
        // Move the butterfly in the current random direction
        transform.Translate(randomDirection * speed * Time.deltaTime);

        // Timer to change direction after a certain amount of time
        timer += Time.deltaTime;
        if (timer > changeDirectionTime)
        {
            SetNewRandomDirection();
            timer = 100f;
        }
    }

    // Generates a new random direction for the butterfly to fly towards
    void SetNewRandomDirection()
    {
        // Create a random point in a sphere around the current position
        randomDirection = new Vector3(
            Random.Range(-1f, 1f), // Random x direction
            Random.Range(-0.5f, 0.5f), // Random y direction to give slight up/down motion
            Random.Range(-1f, 1f)  // Random z direction
        ).normalized;

        // Adjust y-axis for flight height
        randomDirection.y = Mathf.Clamp(randomDirection.y, -0.5f, 0.5f);
    }
}



