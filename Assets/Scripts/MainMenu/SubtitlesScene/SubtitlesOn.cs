using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesOn : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Disable subtitles for all objects with the "InteractableObject" script
            InteractableObject[] interactableObjects = FindObjectsOfType<InteractableObject>();
            foreach (InteractableObject obj in interactableObjects)
            {
                obj.SetCubeInteracted(false);
            }
        }
    }
}
