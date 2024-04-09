using UnityEngine;

public class SceneBootstrapper : MonoBehaviour
{
    public GameObject[] patientPrefabs;
    private ISpawnPointProvider spawnPointProvider;
    private ISpawnPointAdjuster spawnPointAdjuster;

    void Start()
    {
        spawnPointProvider = new SpawnPointProvider();
        spawnPointAdjuster = new SpawnPointAdjuster();
        
        if (spawnPointProvider == null || spawnPointAdjuster == null)
        {
            Debug.LogError("spawnPointProvider/SpawnPointAdjuster not set");
            return;
        }

        SpawnPrefabsAtRandomPoints(patientPrefabs.Length);
    }

    private void SpawnPrefabsAtRandomPoints(int numPrefabsToSpawn)
    {
        if (patientPrefabs.Length == 0)
        {
            Debug.LogError("Prefabs not assigned.");
            return;
        }

        for (int i = 0; i < numPrefabsToSpawn; i++)
        {
            int prefabIndex = GetRandomPrefabIndex();

            // Get a random spawn point from the spawnPointProvider
            Transform spawnPoint = spawnPointProvider.GetRandomSpawnPoint();
            if (spawnPoint == null)
            {
                Debug.LogError("Failed to get a random spawn point.");
                return;
            }

            // Calculate offsets
            float yOffset = CalculateYOffset(spawnPoint);
            float prefabOffset = CalculatePrefabOffset(patientPrefabs[prefabIndex]);

            // Calculate spawn position
            Vector3 spawnPosition = CalculateSpawnPosition(spawnPoint, yOffset, prefabOffset);

            // Instantiate the prefab at the adjusted spawn position
            Instantiate(patientPrefabs[prefabIndex], spawnPosition, Quaternion.identity);
        }
    }

    private int GetRandomPrefabIndex()
    {
        return Random.Range(0, patientPrefabs.Length);
    }

    private float CalculateYOffset(Transform spawnPoint)
    {
        return spawnPoint.GetComponent<PatientSpawnPoint>().GetHeightFromSurface();
    }

    private float CalculatePrefabOffset(GameObject prefab)
    {
        return spawnPointAdjuster.GetYOffsetForPrefab(prefab);
    }

    private Vector3 CalculateSpawnPosition(Transform spawnPoint, float yOffset, float prefabOffset)
    {
        float spawnYPosition = spawnPoint.position.y + yOffset + prefabOffset;
        return new Vector3(spawnPoint.position.x, spawnYPosition, spawnPoint.position.z);
    }
}