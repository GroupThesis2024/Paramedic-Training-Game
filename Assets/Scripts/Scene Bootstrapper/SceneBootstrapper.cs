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

        private List<IGameObjectSpawner> spawnerComponents = new List<IGameObjectSpawner>();

        private GameEvents gameEventsListener;

        void Start()
        {
            TryToGetSpawnerComponentsWithTag();
            SpawnEverythingInSubscribedSpawners();
        }

        private void TryToGetSpawnerComponentsWithTag()
        {
            GameObject[] GetSpawnerGameObjectsResult = GameObject.FindGameObjectsWithTag(objectSpawnerTag);
            foreach (GameObject GameObjectTaggedAsSpawner in GetSpawnerGameObjectsResult)
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