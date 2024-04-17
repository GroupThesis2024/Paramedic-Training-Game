using System;
using UnityEngine;

namespace LevelLoader
{
    /// <summary>
    /// Responsible for handling prefab instantiation in the scene, allows for controlling multiple spawners.
    /// </summary>
    public class SceneBootstrapper : MonoBehaviour
    {
        private enum Spawners
        {
            PatientSpawner,
        }

        private GameObject[] spawnerGameObjects;

        private IGameObjectSpawner[] spawnerComponents;

        private GameEvents gameEventsListener;

        void Start()
        {
            TryToGetSubscribedSpawnerGameObjects();
            TryToGetSpawnerComponents();
            SpawnEverythingInSubscribedSpawners();
        }

        private void TryToGetSubscribedSpawnerGameObjects()
        {
            string[] spawnersAvailable = Enum.GetNames(typeof(Spawners));
            int amountOfSpawners = spawnersAvailable.Length;
            GameObject[] GetSpawnerGameObjectsResult = new GameObject[amountOfSpawners];
            for (int i = 0; i < amountOfSpawners; i++)
            {
                GetSpawnerGameObjectsResult[i] = GameObject.FindGameObjectWithTag(spawnersAvailable[i]);
            }
            EnsureSpawnerGameObjectsAreSet(GetSpawnerGameObjectsResult);
            spawnerGameObjects = GetSpawnerGameObjectsResult;
        }

        private void EnsureSpawnerGameObjectsAreSet(GameObject[] gameObject)
        {
            /// <summary>Array.IndexOf() returns -1 if no result is found.</summary>
            bool patientSpawnPointsContainsNull = Array.IndexOf(gameObject, null) != -1;
            if (patientSpawnPointsContainsNull)
            {
                throw new UnassignedReferenceException("Spawner script/scripts not found. " +
                "Have Spawner GameObjects been assigned their respectful Spawner scripts?");
            }
        }

        private void TryToGetSpawnerComponents()
        {
            int amountOfGameObjects = spawnerGameObjects.Length;
            IGameObjectSpawner[] GetSpawnerComponentsResult = new IGameObjectSpawner[amountOfGameObjects];
            for (int i = 0; i < amountOfGameObjects; i++)
            {
                GetSpawnerComponentsResult[i] = (IGameObjectSpawner)spawnerGameObjects[i].GetComponent(typeof(IGameObjectSpawner));
            }
            EnsureSpawnerComponentsAreSet(GetSpawnerComponentsResult);
            spawnerComponents = GetSpawnerComponentsResult;
        }

        private void EnsureSpawnerComponentsAreSet(IGameObjectSpawner[] gameObject)
        {
            /// <summary>Array.IndexOf() returns -1 if no result is found.</summary>
            bool patientSpawnPointsContainsNull = Array.IndexOf(gameObject, null) != -1;
            if (patientSpawnPointsContainsNull)
            {
                throw new UnassignedReferenceException("Incorrect Spawner script. " +
                "Do all Spawner scripts implement IGameObjectSpawner interface?");
            }
        }

        private void SpawnEverythingInSubscribedSpawners()
        {
            bool spawnersComponentsArrayIsEmpty = spawnerComponents.Length == 0;
            if (spawnersComponentsArrayIsEmpty)
            {
                ThrowGameObjectSpawnerNotAssignedError();
            }
            else
            {
                foreach (IGameObjectSpawner spawner in spawnerComponents)
                {
                    spawner.SpawnEverything();
                }
            }
        }

        private void ThrowGameObjectSpawnerNotAssignedError()
        {
            throw new UnassignedReferenceException("Subscribed spawners not found. Has SceneBootstrapper been assigned a Spawner in the inspector?");
        }
    }
}