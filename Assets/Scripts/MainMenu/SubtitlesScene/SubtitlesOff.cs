using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesOff: MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
    if (collision.gameObject.CompareTag("Player"))
        {
            // Disable subtitles for all objects
            SubtitlesManager subtitlesManager = SubtitlesManager.Instance;
            if (subtitlesManager != null)
            {
                GameObject[] objectsWithSubtitles = GameObject.FindGameObjectsWithTag("ObjectWithSubtitles");
                foreach (GameObject obj in objectsWithSubtitles)
                {
                    subtitlesManager.DisableAllSubtitles(obj);
                }
            }

            // Set the cubeInteracted flag on all objects with the ObjectInteraction script
            InteractableObject[] objectInteractions = FindObjectsOfType<InteractableObject>();
            foreach (InteractableObject objInteraction in objectInteractions)
            {
                objInteraction.SetCubeInteracted(true);
            }
        }
    }
}

