using UnityEngine;

namespace LevelLoader
{
    public class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField]
        IGameObjectSpawner[] subscribedSpawners;
        GameEvents gameEventsListener;

        void Start()
        {
            spawnEverythingInSubscribedSpawners();
        }

        private void spawnEverythingInSubscribedSpawners()
        {
            bool subscribedSpawnersArrayIsEmpty = subscribedSpawners.Length == 0;
            if (subscribedSpawnersArrayIsEmpty)
            {
                ThrowGameObjectSpawnerNotAssignedError();
            }
            else
            {
                foreach (IGameObjectSpawner gameObjectSpawner in subscribedSpawners)
                {
                    gameObjectSpawner.SpawnEverything();
                }
            }

        }

        private void ThrowGameObjectSpawnerNotAssignedError()
        {
            throw new UnassignedReferenceException("Subscribed spawners not found. Has SceneBootstrapper been assigned a Spawner in the inspector?");
        }
    }

}