using UnityEngine;

public interface ISpawnPointAdjuster
{
    public float GetYOffsetForPrefab(GameObject prefab);
}