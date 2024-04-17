using System;
using System.Linq;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace LevelLoader
{
    /// <summary>
    /// Responsible for handling <b>Patient</b> prefab instantiation in the scene, controlled by SceneBootstrapper.
    /// </summary>
    public class PatientSpawner : MonoBehaviour, IGameObjectSpawner
    {
        [SerializeField]
        private GameObject patientPrefab;

        [SerializeField]
        private string patientSpawnPointTag;

        private float patientPrefabHeightOffset;

        private GameObject[] patientSpawnPointGameObjects;

        private PatientSpawnPoint[] patientSpawnPoints;

        void Awake()
        {
            EnsurePatientPrefabIsSet();
            EnsureSpawnPointTagIsSet();
        }

        private void EnsurePatientPrefabIsSet()
        {
            bool patientPrefabIsNull = patientPrefab == null;
            if (patientPrefabIsNull)
            {
                throw new UnassignedReferenceException("Patient Prefab not found. " +
                "Has a prefab been assigned for it in the inspector?");
            }
        }

        private void EnsureSpawnPointTagIsSet()
        {
            bool stringIsNullOrEmpty = patientSpawnPointTag == null || patientSpawnPointTag == "";
            if (stringIsNullOrEmpty)
            {
                throw new UnassignedReferenceException("Patient Spawn Point Tag not found or empty. " +
                "Has a string been assigned for it in the inspector?");
            }
        }

        private void Start()
        {
            TryToGetPatientSpawnPoints();
            TryToGetPatientPrefabHeightOffset();
            float[] distancesFromSurface = TryToGetDistanceFromSurfaceForGameObjects();
            CalculatePatientSpawnPointsWithOffsets(distancesFromSurface);
        }

        private void TryToGetPatientSpawnPoints()
        {
            TryToGetPatientSpawnPointGameObjectsWithTag();
            TryToGetPatientSpawnPointComponents();
        }


        private void TryToGetPatientSpawnPointGameObjectsWithTag()
        {
            GameObject[] findPatientSpawnPointGameObjectResult = GameObject.FindGameObjectsWithTag(patientSpawnPointTag);
            EnsurePatientSpawnPointGameObjectsAreSet(findPatientSpawnPointGameObjectResult);
            patientSpawnPointGameObjects = findPatientSpawnPointGameObjectResult;
        }

        private void EnsurePatientSpawnPointGameObjectsAreSet(GameObject[] gameObjects)
        {
            bool patientSpawnPointGameObjectsAreNullOrEmpty = gameObjects == null || gameObjects.Length == 0;
            if (patientSpawnPointGameObjectsAreNullOrEmpty)
            {
                throw new UnityException("GameObjects not found with tag: " + patientSpawnPointTag +
                ". Have GameObjects holding PatientSpawnPoint script been assigned a correct tag?");
            }
        }

        private void TryToGetPatientSpawnPointComponents()
        {
            int lengthOfGameObjectsArray = patientSpawnPointGameObjects.Length;
            PatientSpawnPoint[] patientSpawnPointComponents = new PatientSpawnPoint[lengthOfGameObjectsArray];
            for (int i = 0; i < lengthOfGameObjectsArray; i++)
            {
                patientSpawnPointComponents[i] = patientSpawnPointGameObjects[i].GetComponent<PatientSpawnPoint>();
            }
            EnsurePatientSpawnPointComponentsAreSet(patientSpawnPointComponents);
            patientSpawnPoints = patientSpawnPointComponents;
        }

        private void EnsurePatientSpawnPointComponentsAreSet(PatientSpawnPoint[] patientSpawnPoints)
        {
            /// <summary>Array.IndexOf() returns -1 if no result is found.</summary>
            bool patientSpawnPointsContainsNull = Array.IndexOf(patientSpawnPoints, null) != -1;
            if (patientSpawnPointsContainsNull)
            {
                throw new UnassignedReferenceException("PatientSpawnPoint script/scripts not found. " +
                "Have PatientSpawnPoint GameObjects been assigned PatientSpawnPoint scripts?");
            }
        }

        private void TryToGetPatientPrefabHeightOffset()
        {
            Renderer patientPrefabRenderer = TryToGetPatientPrefabRenderer();
            patientPrefabHeightOffset = TryToGetPatientPrefabBoundsExtentsY(patientPrefabRenderer);
        }

        private Renderer TryToGetPatientPrefabRenderer()
        {
            Renderer patientPrefabRenderer = patientPrefab.GetComponent<Renderer>();
            bool rendererIsNull = patientPrefabRenderer == null;
            if (rendererIsNull)
            {
                throw new UnityException("Renderer for PatientPrefab not found. " +
                    "Ensure that prefab is of suitable type");
            }
            return patientPrefabRenderer;
        }

        private float TryToGetPatientPrefabBoundsExtentsY(Renderer patientPrefabRenderer)
        {
            bool boundsAreNullOrZero = patientPrefabRenderer.bounds == null || patientPrefabRenderer.bounds.size == Vector3.zero;
            if (boundsAreNullOrZero)
            {
                throw new UnityException("Bounds for PatientPrefab are: not found / set to zero. " +
                    "Ensure that prefab is of suitable type");
            }
            return patientPrefabRenderer.bounds.extents.y;
        }

        private float[] TryToGetDistanceFromSurfaceForGameObjects()
        {
            int lengthOfGameObjectsArray = patientSpawnPointGameObjects.Length;
            float[] distancesFromSurface = new float[lengthOfGameObjectsArray];
            for (int i = 0; i < lengthOfGameObjectsArray; i++)
            {
                distancesFromSurface[i] = CalculateDistanceFromSurface(patientSpawnPointGameObjects[i]);
            }
            EnsureDistancesFromSurfaceAreSet(distancesFromSurface);
            return distancesFromSurface;
        }

        private float CalculateDistanceFromSurface(GameObject gameObject)
        {
            RaycastHit hit;
            Vector3 PatientSpawnPointPosition = gameObject.transform.position;
            Vector3 RaycastDirectionDown = transform.TransformDirection(Vector3.down);
            Physics.Raycast(PatientSpawnPointPosition, RaycastDirectionDown, out hit);
            return hit.distance;
        }

        private void EnsureDistancesFromSurfaceAreSet(float[] distancesFromSurface)
        {
            /// <summary>
            /// Array.IndexOf() returns -1 if no result is found.
            /// Array.Any(i => i < 0) to check if negative result is found
            /// </summary>
            bool distancesFromSurfaceContainsNullOrNegative = Array.IndexOf(distancesFromSurface, null) != -1 || distancesFromSurface.Any(i => i < 0);
            if (distancesFromSurfaceContainsNullOrNegative)
            {
                throw new UnassignedReferenceException("Raycast returned: Null / Negative Value " +
                "Are PatientSpawnPoint GameObjects clipping the ground surface or under the surface");
            }
        }

        private void CalculatePatientSpawnPointsWithOffsets(float[] distancesFromGround)
        {
            int lengthOfGameObjectsArray = patientSpawnPointGameObjects.Length;
            for (int i = 0; i < lengthOfGameObjectsArray; i++)
            {
                Vector3 positionTemp = patientSpawnPointGameObjects[i].transform.position;
                positionTemp.y = positionTemp.y - distancesFromGround[i] + patientPrefabHeightOffset;
                patientSpawnPointGameObjects[i].transform.position = positionTemp;
            }
        }

        public void SpawnEverything()
        {
            foreach (GameObject patientSpawnPointGameObject in patientSpawnPointGameObjects)
            {
                Instantiate(patientPrefab, patientSpawnPointGameObject.transform.position, Quaternion.identity);
            }
        }
    }
}