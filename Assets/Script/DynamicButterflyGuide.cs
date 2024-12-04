using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicButterflyGuide : MonoBehaviour
{
    [Header("Butterfly Settings")]
    public GameObject butterflyPrefab; // Butterfly prefab
    public Transform targetObject; // Target the butterflies are guiding to
    public int maxButterflies = 5; // Max butterflies at any time
    public float spawnInterval = 1f; // Time between spawns
    public float floatAmplitude = 0.5f; // Amplitude for floating effect
    public float floatFrequency = 1f; // Frequency for floating effect
    public float moveSpeed = 2f; // Speed butterflies move toward the target
    public float spawnDistance = 2f; // Distance in front of the player to spawn butterflies
    public float horizontalSpread = 1f; // Side-to-side spread for butterflies
    public float verticalOffset = 1f; // Vertical offset for butterflies

    private Transform playerTransform; // Reference to the player's transform
    private float spawnTimer = 0f; // Timer for spawning butterflies
    public bool butterflyTriggered = false; // Boolean to trigger the butterfly effect

    void Start()
    {
        playerTransform = transform; // Assume script is attached to the player
        if (butterflyPrefab == null || targetObject == null)
        {
            Debug.LogError("ButterflyPrefab or TargetObject is not assigned!");
        }
    }

    void Update()
    {
        if (butterflyTriggered)
        {
            spawnTimer += Time.deltaTime;

            // Spawn a butterfly at intervals
            if (spawnTimer >= spawnInterval && maxButterflies > 0)
            {
                SpawnButterfly();
                spawnTimer = 0f;
            }
        }
        // Butterflies can still float/move toward the target, even if not triggered
        else
        {
            Debug.Log("Butterfly is idle or waiting to be triggered.");
        }
    }

    void SpawnButterfly()
    {
        // Calculate a spawn position in front of the player
        Vector3 spawnPosition = playerTransform.position +
            playerTransform.forward * spawnDistance + // In front of the player
            playerTransform.right * Random.Range(-horizontalSpread, horizontalSpread) + // Random horizontal offset
            new Vector3(0, verticalOffset, 0); // Vertical offset

        GameObject butterfly = Instantiate(butterflyPrefab, spawnPosition, Quaternion.identity);

        // Add the behavior script to guide the butterfly
        butterfly.AddComponent<DynamicButterflyBehavior>().Initialize(
            targetObject,
            floatAmplitude,
            floatFrequency,
            moveSpeed
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touches the butterfly
        if (other.CompareTag("Player"))
        {
            butterflyTriggered = true; // Activate butterfly effect
            Debug.Log("Butterfly triggered!");
        }
    }
}

public class DynamicButterflyBehavior : MonoBehaviour
{
    private Transform target;
    private float floatAmplitude;
    private float floatFrequency;
    private float moveSpeed;

    private Vector3 initialPosition; // Starting position for floating effect

    public void Initialize(Transform targetObject, float amplitude, float frequency, float speed)
    {
        target = targetObject;
        floatAmplitude = amplitude;
        floatFrequency = frequency;
        moveSpeed = speed;
        initialPosition = transform.position;
    }

    void Update()
    {
        // Floating Effect
        Vector3 floatOffset = new Vector3(0, Mathf.Sin(Time.time * floatFrequency) * floatAmplitude, 0);

        // Move Toward Target
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        // Apply floating offset
        transform.position += floatOffset * Time.deltaTime;

        // Optional: Orient towards the target
        if (target != null)
        {
            Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);
        }
    }
}
