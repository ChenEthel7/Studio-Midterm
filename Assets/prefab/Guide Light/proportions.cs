using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProportionalMovement : MonoBehaviour
{
    public Transform targetObject;  // Object to move and scale proportionally
    public Vector3 startScale;      // Initial scale of the object
    public Vector3 startPosition;   // Initial position of the object
    public float scaleFactor = 0.01f;  // Factor to scale based on distance

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = targetObject.position;
        startScale = targetObject.localScale;
    }

    void Update()
    {
        // Calculate the distance the object has moved from the initial position
        float distanceMoved = Vector3.Distance(initialPosition, targetObject.position);

        // Scale the object proportionally based on the distance moved
        targetObject.localScale = startScale + (startScale * distanceMoved * scaleFactor);
    }
}
