using System.Collections.Generic;
using UnityEngine;

public class SpawnPointProvider : MonoBehaviour, ISpawnPointProvider
{
    private List<Transform> spawnPoints = new List<Transform>();
    private List<Transform> clonedSpawnPoints;

    private void Awake()
    {
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("PatientSpawnPoint");
        foreach (GameObject spawnPointObject in spawnPointObjects)
        {
            spawnPoints.Add(spawnPointObject.transform);
        }
        clonedSpawnPoints = new List<Transform>(spawnPoints);
    }

    public Transform GetRandomSpawnPoint()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogError("No spawn points found.");
            return null;
        }

        int randomIndex = Random.Range(0, clonedSpawnPoints.Count);
        Transform spawnPoint = clonedSpawnPoints[randomIndex];
        clonedSpawnPoints.RemoveAt(randomIndex);

        return spawnPoint;
    }
}