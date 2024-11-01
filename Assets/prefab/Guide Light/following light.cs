using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidingLight : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float distanceInFront = 3f;  // Distance in front of the player

    void Update()
    {
        // Move the light object a certain distance in front of the player
        Vector3 newPosition = player.position + player.forward * distanceInFront;
        transform.position = newPosition;
    }
}
