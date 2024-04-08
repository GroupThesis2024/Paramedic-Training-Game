using UnityEngine;

public class SpawnPointAdjuster : MonoBehaviour, ISpawnPointAdjuster
{
    public Vector3 AdjustSpawnPointForPrefab(GameObject prefab, Vector3 spawnPoint)
    {
        Bounds bounds = GetPrefabBounds(prefab);
        float yOffset = bounds.extents.y; // Get extents for y and store as yOffset
        return new Vector3(spawnPoint.x, spawnPoint.y + yOffset, spawnPoint.z);
    }

    private Bounds GetPrefabBounds(GameObject prefab)
    {
        Renderer[] renderers = prefab.GetComponentsInChildren<Renderer>();
        Bounds bounds = new Bounds();
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }
        return bounds;
    }
}