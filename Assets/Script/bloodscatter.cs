using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class bloodscatter : MonoBehaviour
{
    public LineRenderer lineRenderer;  // Assign the Line Renderer in the Inspector
    public Transform target;           // Assign the target object in the Inspector
    public float pointSpacing = 2.0f;  // Distance between points along the trail
    public float scatterRange = 0.5f;  // Random scatter range for blood points
    public float offsetHeight = 0.01f; // Height offset above the terrain

    private List<Vector3> randomOffsets = new List<Vector3>();

    void Start()
    {
        if (target != null)
        {
            InitializeRandomOffsets();
        }
    }

    void Update()
    {
        if (target != null)
        {
            GenerateDynamicTrail();
            UpdateLineRenderer();
        }
    }

    void InitializeRandomOffsets()
    {
        // Generate a list of random offsets for the trail points
        int maxPoints = Mathf.CeilToInt(Vector3.Distance(transform.position, target.position) / pointSpacing);
        randomOffsets.Clear();

        for (int i = 0; i <= maxPoints; i++)
        {
            randomOffsets.Add(new Vector3(
                Random.Range(-scatterRange, scatterRange), // Random X scatter
                0,
                Random.Range(-scatterRange, scatterRange)  // Random Z scatter
            ));
        }
    }

    void GenerateDynamicTrail()
    {
        Vector3 playerPosition = transform.position;
        Vector3 targetPosition = target.position;

        // Determine the direction and distance between player and target
        Vector3 direction = (targetPosition - playerPosition).normalized;
        float distance = Vector3.Distance(playerPosition, targetPosition);

        // Generate points along the path
        List<Vector3> trailPoints = new List<Vector3>();
        int offsetIndex = 0;

        for (float d = 0; d <= distance; d += pointSpacing)
        {
            Vector3 point = playerPosition + direction * d;

            // Apply pre-generated random scatter
            if (offsetIndex < randomOffsets.Count)
            {
                point += randomOffsets[offsetIndex];
                offsetIndex++;
            }

            // Raycast to place the point on the terrain
            RaycastHit hit;
            if (Physics.Raycast(point + Vector3.up, Vector3.down, out hit, Mathf.Infinity))
            {
                trailPoints.Add(hit.point + Vector3.up * offsetHeight);
            }
        }

        // Update the random offsets if the number of points changes
        if (trailPoints.Count > randomOffsets.Count)
        {
            InitializeRandomOffsets();
        }

        // Update Line Renderer positions
        lineRenderer.positionCount = trailPoints.Count;
        lineRenderer.SetPositions(trailPoints.ToArray());
    }

    void UpdateLineRenderer()
    {
        // The Line Renderer positions are updated in GenerateDynamicTrail
    }
}
