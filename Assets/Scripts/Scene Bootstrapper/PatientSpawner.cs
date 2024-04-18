using System;
using System.Collections.Generic;
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

        private List<PatientSpawnPoint> patientSpawnPoints = new List<PatientSpawnPoint>();

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
            TryToGetPatientSpawnPointsWithTag();
            TryToGetPatientPrefabHeightOffset();
            float[] distancesFromSurface = TryToGetDistanceFromSurfaceForGameObjects();
            CalculatePatientSpawnPointsWithOffsets(distancesFromSurface);
        }

        private void TryToGetPatientSpawnPointsWithTag()
        {
            patientSpawnPointGameObjects = GameObject.FindGameObjectsWithTag(patientSpawnPointTag);
            foreach (GameObject patientSpawnPointGameObject in patientSpawnPointGameObjects)
            {
                PatientSpawnPoint foundPatientSpawnPointComponents =
                patientSpawnPointGameObject.GetComponent<PatientSpawnPoint>();
                if (foundPatientSpawnPointComponents != null)
                {
                    patientSpawnPoints.Add(foundPatientSpawnPointComponents);
                }
            }
        }

        private void TryToGetPatientPrefabHeightOffset()
        {
            Collider patientPrefabCollider = TryToGetPatientPrefabCollider();
            patientPrefabHeightOffset = TryToGetPatientPrefabBoundsExtentsY(patientPrefabCollider);
        }

        private Collider TryToGetPatientPrefabCollider()
        {
            GameObject prefabToGetColliderOff = Instantiate(patientPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Collider patientPrefabCollider = prefabToGetColliderOff.GetComponent<Collider>();
            bool ColliderIsNull = patientPrefabCollider == null;
            if (ColliderIsNull)
            {
                throw new UnityException("Collider for PatientPrefab not found. " +
                    "Ensure that prefab is of suitable type");
            }
            Destroy(prefabToGetColliderOff);
            return patientPrefabCollider;
        }

        private float TryToGetPatientPrefabBoundsExtentsY(Collider patientPrefabCollider)
        {
            bool boundsAreNullOrZero = patientPrefabCollider.bounds == null || patientPrefabCollider.bounds.size == Vector3.zero;
            if (boundsAreNullOrZero)
            {
                throw new UnityException("Bounds for PatientPrefab are: not found / set to zero. " +
                    "Ensure that prefab is of suitable type");
            }
            return patientPrefabCollider.bounds.extents.y;
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