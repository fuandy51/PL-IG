using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    public List<GameObject> prefabsToSpawn; // List of prefabs to spawn
    public float spawnY; // Fixed Y position for spawning
    public float minX; // Minimum X position for spawn point
    public float maxX; // Maximum X position for spawn point
    public float spawnInterval = 1f; // Time interval between spawns (in seconds)

    private void Start()
    {
        // Start the coroutine for spawning objects repeatedly
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Pick a random prefab from the list
            GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Count)];

            // Check if an instance of this prefab (or a clone of it) already exists in the scene
            if (IsPrefabAlreadyExisting(prefabToSpawn))
            {
                // Skip spawning and continue to the next iteration
                yield return new WaitForSeconds(spawnInterval);
                continue;
            }

            // Create a new random spawn position
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), spawnY);

            // Instantiate the prefab at the spawn position
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // Wait before the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private bool IsPrefabAlreadyExisting(GameObject prefab)
    {
        // Get all objects in the scene
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // Check if any object has a name that starts with the prefab's name
        foreach (GameObject obj in allObjects)
        {
            if (obj.name.StartsWith(prefab.name))
            {
                return true; // Found an existing object with a matching name
            }
        }

        return false; // No matching object found
    }
}
