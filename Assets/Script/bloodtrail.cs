using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

public class ScatteredBloodTrail : MonoBehaviour
{
    public LineRenderer lineRenderer; // Assign the Line Renderer in the Inspector
    public Transform target;          // Assign the target object in the Inspector
    public float pointSpacing = 1.0f; // Distance between points along the trail
    public float offsetHeight = 0.01f; // Height offset above terrain
    public float scatterRange = 0.5f; // How much the trail scatters randomly

    private List<Vector3> trailPoints = new List<Vector3>();

    void Start()
    {
        lineRenderer.positionCount = 0; // Initialize the Line Renderer
    }

    void Update()
    {
        if (target != null)
        {
            GenerateTrail();
            UpdateLineRenderer();
        }
    }

    void GenerateTrail()
    {
        trailPoints.Clear(); // Clear old trail points

        Vector3 playerPosition = transform.position;
        Vector3 targetPosition = target.position;

        // Determine the direction between the player and the target
        Vector3 direction = (targetPosition - playerPosition).normalized;
        float distance = Vector3.Distance(playerPosition, targetPosition);

        // Raycast along the path to find points on the terrain
        for (float d = 0; d <= distance; d += pointSpacing)
        {
            Vector3 point = playerPosition + direction * d;

            // Add randomness to scatter the trail
            Vector3 randomOffset = new Vector3(
                Random.Range(-scatterRange, scatterRange), // Random X offset
                0,
                Random.Range(-scatterRange, scatterRange)  // Random Z offset
            );
            point += randomOffset;

            // Raycast downward to place the point on the terrain
            RaycastHit hit;
            if (Physics.Raycast(point + Vector3.up, Vector3.down, out hit, Mathf.Infinity))
            {
                trailPoints.Add(hit.point + Vector3.up * offsetHeight);
            }
        }
    }

    void UpdateLineRenderer()
    {
        lineRenderer.positionCount = trailPoints.Count;
        lineRenderer.SetPositions(trailPoints.ToArray());
    }
}
