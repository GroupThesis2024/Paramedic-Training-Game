using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelLoader
{
    /// <summary>
    /// Responsible for handling prefab instantiation in the scene, allows for controlling multiple spawners.
    /// </summary>
    public class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField]
        private string objectSpawnerTag;

        private GameObject[] spawnerGameObjects;

        private List<IGameObjectSpawner> spawnerComponents = new List<IGameObjectSpawner>();

        private GameEvents gameEventsListener;

        void Start()
        {
            TryToGetSubscribedSpawnerGameObjects();
            EnsureSpawnerGameObjectsAreSet();
            TryToGetSpawnerComponents();
            SpawnEverythingInSubscribedSpawners();
        }

        private void TryToGetSubscribedSpawnerGameObjects()
        {
            GameObject[] GetSpawnerGameObjectsResult = GameObject.FindGameObjectsWithTag(objectSpawnerTag);
            spawnerGameObjects = GetSpawnerGameObjectsResult;
        }

        private void EnsureSpawnerGameObjectsAreSet()
        {
            /// <summary>Array.IndexOf() returns -1 if no result is found.</summary>
            bool patientSpawnPointsContainsNull = Array.IndexOf(spawnerGameObjects, null) != -1;
            if (patientSpawnPointsContainsNull)
            {
                Debug.LogWarning("Couldn't find any tagged object spawners in the scene. Have you assigned tags correctly to these game objects?");
            }
        }

        private void TryToGetSpawnerComponents()
        {
            foreach (GameObject GameObjectTaggedAsSpawner in spawnerGameObjects)
            {
                IGameObjectSpawner foundSpawnerInterfaceInTaggedGameObject =
                GameObjectTaggedAsSpawner.GetComponent<IGameObjectSpawner>();
                if (foundSpawnerInterfaceInTaggedGameObject != null)
                {
                    spawnerComponents.Add(foundSpawnerInterfaceInTaggedGameObject);
                }
            }
        }

        private void SpawnEverythingInSubscribedSpawners()
        {
            foreach (IGameObjectSpawner spawner in spawnerComponents)
            {
                spawner.SpawnEverything();
            }
        }
    }
}