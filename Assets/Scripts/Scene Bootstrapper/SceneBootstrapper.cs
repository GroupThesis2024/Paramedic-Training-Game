using UnityEngine;

public class SceneBootstrapper : MonoBehaviour
{
    public GameObject[] patientPrefabs;
    [SerializeField] ISpawnPointProvider spawnPointProvider;
    [SerializeField] ISpawnPointAdjuster spawnPointAdjuster;

    void Start()
    {
        // Find the SpawnPointProvider in the scene
        
        if (spawnPointProvider == null || spawnPointAdjuster == null)
        {
            Debug.LogError("spawnPointProvider/SpawnPointAdjuster not found in the scene.");
            return;
        }

        SpawnPrefabsAtRandomPoints(patientPrefabs.Length);
    }

    public void SpawnPrefabsAtRandomPoints(int numPrefabsToSpawn)
    {
        if (patientPrefabs.Length == 0)
        {
            Debug.LogError("Prefabs not assigned.");
            return;
        }

        for (int i = 0; i < numPrefabsToSpawn; i++)
        {
            int prefabIndex = Random.Range(0, patientPrefabs.Length);

            // Get a random spawn point from the SpawnPointManager
            Transform spawnPoint = spawnPointProvider.GetRandomSpawnPoint();
            if (spawnPoint == null)
            {
                Debug.LogError("Failed to get a random spawn point.");
                return;
            }

            // Adjust the spawn position for the prefab
            Vector3 spawnPosition = spawnPointAdjuster.AdjustSpawnPointForPrefab(patientPrefabs[prefabIndex], spawnPoint.position);

            // Instantiate the prefab at the adjusted spawn position
            Instantiate(patientPrefabs[prefabIndex], spawnPosition, Quaternion.identity);
        }
    }
}