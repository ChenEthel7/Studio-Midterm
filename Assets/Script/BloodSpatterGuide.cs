using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpatterGuide : MonoBehaviour
{
    public GameObject bloodSpatterPrefab; // Assign the prefab in Inspector
    public Transform player; // Assign the player GameObject in Inspector
    public Transform targetObject; // Assign the target object in Inspector
    public int numberOfSpatters = 5; // Number of active blood spatters at a time
    public float spawnDistance = 2f; // Distance ahead of the player to place blood spatters
    public float scatterRange = 1f; // Range for random scatter offsets
    public float fadeDuration = 2f; // Duration for fade-out
    public float updateInterval = 0.5f; // Time between spatter updates
    public LayerMask groundLayer; // Set the ground layer in the Inspector

    private Queue<GameObject> bloodSpatters = new Queue<GameObject>();
    private List<float> spatterTimers = new List<float>(); // Track fade-out timers
    private float nextUpdateTime;

    void Update()
    {
        if (Time.time >= nextUpdateTime)
        {
            nextUpdateTime = Time.time + updateInterval;
            UpdateBloodPath();
        }

        FadeOutSpatters();
    }

    void UpdateBloodPath()
    {
        Vector3 playerPosition = player.position;
        Vector3 directionToTarget = (targetObject.position - playerPosition).normalized;

        for (int i = 0; i < numberOfSpatters; i++)
        {
            float t = (i + 1) * spawnDistance;
            Vector3 spawnPoint = playerPosition + directionToTarget * t;

            // Add random scatter offsets
            spawnPoint.x += Random.Range(-scatterRange, scatterRange);
            spawnPoint.z += Random.Range(-scatterRange, scatterRange);

            // Use Raycast to adjust spawnPoint to the terrain height
            if (Physics.Raycast(spawnPoint + Vector3.up * 10f, Vector3.down, out RaycastHit hit, 20f, groundLayer))
            {
                spawnPoint = hit.point;

                // If not enough blood spatters, create new ones
                if (bloodSpatters.Count < numberOfSpatters)
                {
                    GameObject spatter = Instantiate(bloodSpatterPrefab, spawnPoint, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    bloodSpatters.Enqueue(spatter);
                    spatterTimers.Add(0f); // Start fade timer
                }
                else
                {
                    // Reuse existing spatter by moving it
                    GameObject spatter = bloodSpatters.Dequeue();
                    spatter.transform.position = spawnPoint;
                    bloodSpatters.Enqueue(spatter);
                    spatterTimers[bloodSpatters.Count - 1] = 0f; // Reset fade timer
                }
            }
        }
    }

    void FadeOutSpatters()
    {
        for (int i = 0; i < bloodSpatters.Count; i++)
        {
            GameObject spatter = bloodSpatters.ToArray()[i];
            spatterTimers[i] += Time.deltaTime;

            if (spatterTimers[i] >= fadeDuration)
            {
                spatter.SetActive(false); // Hide spatter after fade duration
            }
            else
            {
                // Gradually fade out the spatter (requires material with transparency)
                float alpha = Mathf.Lerp(1f, 0f, spatterTimers[i] / fadeDuration);
                Renderer renderer = spatter.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Color color = renderer.material.color;
                    color.a = alpha;
                    renderer.material.color = color;
                }
            }
        }
    }
}
