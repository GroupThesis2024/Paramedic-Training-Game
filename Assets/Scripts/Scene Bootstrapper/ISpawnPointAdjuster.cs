using UnityEngine;

public interface ISpawnPointAdjuster
{
    Vector3 AdjustSpawnPointForPrefab(GameObject prefab, Vector3 spawnPoint);
}