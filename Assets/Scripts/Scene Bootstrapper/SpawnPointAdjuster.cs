using UnityEngine;

public class SpawnPointAdjuster : ISpawnPointAdjuster
{
    public float GetYOffsetForPrefab(GameObject prefab)
    {
        float prefabHeight = GetPrefabHeight(prefab);
        if (prefabHeight <= 0f)
        {
            Debug.LogWarning("Prefab height calculation failed or returned invalid value.");
            return 0f; // Return a default offset
        }

        float yOffset = prefabHeight * GetVerticalPivotOffset(prefab); // Get the pivot offset instead of just multiplying by 0.5
        return yOffset;
    }

    private float GetPrefabHeight(GameObject prefab)
    {
        Bounds bounds = GetCombinedBounds(prefab);
        return bounds.size.y;
    }

    private float GetVerticalPivotOffset(GameObject prefab)
    {
        Bounds bounds = GetCombinedBounds(prefab);
        // Calculate the vertical pivot offset
        return (bounds.center.y - bounds.min.y) / bounds.size.y;
    }

    private Bounds GetCombinedBounds(GameObject prefab)
    {
        Renderer[] renderers = prefab.GetComponentsInChildren<Renderer>();
        if (renderers == null || renderers.Length == 0)
        {
            Debug.LogWarning("No renderers found in the prefab or its children.");
            return new Bounds(); // Return an empty bounds
        }

        Bounds bounds = new();
        foreach (Renderer renderer in renderers)
        {
            if (renderer != null && renderer.bounds.size != Vector3.zero)
            {
                bounds.Encapsulate(renderer.bounds);
            }
        }
        return bounds;
    }
}